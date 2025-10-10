# 🧩 .NET GC Deep Dive — Del ciclo de asignación a la recolección (con fragmentación y ejemplos)
**Autor:** Gustavo Rabanal  
**Fecha:** 2025-10-10  
**Entorno de referencia:** .NET 8 (CoreCLR)  

---

## 1) Objetivo y alcance
Este documento explica secuencialmente cómo funciona el Garbage Collector (GC) en .NET, desde la asignación de objetos hasta su recolección, incluyendo:
- Cuándo/por qué se dispara un GC (GC pressure, umbrales, modos).
- Cómo determina qué objetos liberar (reachability y raíces).
- Qué pasa durante una GC pause (hilos suspendidos, fases del GC).
- Fragmentación (qué es, causas, cómo mitigarlo).
- Ejemplos cortos y claros en C# para cada concepto.
- Un diagrama de secuencia (Mermaid) con todos los componentes involucrados.

Nota: Cuando aquí se dice "heap", se refiere al managed heap (memoria administrada por el GC).

---

## 2) Modelo de memoria (visión mínima esencial)
- Stack: valores locales, punteros de retorno, referencias a objetos en heap. De vida corta, ligado al frame de ejecución.
- Managed Heap: donde viven todas las clases y arrays (T[]). Administrado por el GC.
- Generaciones:
  - Gen0: objetos recién creados (efímeros).
  - Gen1: intermedio.
  - Gen2: objetos de larga vida (tenured).
- LOH (Large Object Heap): objetos grandes (aprox. >= 85 KB) como arrays voluminosos. Recolectado con Gen2; no se compacta por defecto salvo cuando se solicita (ver §7.3).
- Objetos pinned: fijados en memoria (no se mueven durante compactación); pueden causar fragmentación.

Ejemplo – arrays y clases siempre en heap:
```csharp
var a = new byte[100];     // heap (Gen0)
var s = new String('x', 10); // heap
```

---

## 3) Asignación: ¿cómo asigna memoria .NET?
- .NET usa un asignador tipo bump-pointer por hilo (contexto de asignación por hilo): reservar en Gen0 es, en la mayoría de casos, incrementar un puntero.
- Esto hace que asignar sea muy rápido... hasta que se agota el presupuesto de Gen0.

Ejemplo – presión de asignación en Gen0:
```csharp
var trash = new List<byte[]>();
for (int i = 0; i < 1_000_000; i++)
{
    trash.Add(new byte[128]); // muchas asignaciones pequeñas -> presión en Gen0
}
```

---

## 4) ¿Qué es GC pressure y quién dispara el GC?
GC pressure = cuánta presión ejercen tus asignaciones y el tamaño/fragmentación del heap sobre los umbrales internos del GC.

El runtime (CLR) monitorea:
- Bytes asignados desde el último GC por generación.
- Tamaños de segmentos de Gen0/1/2 y LOH.
- Señales del SO (presión de memoria del sistema).
- Modos configurados (Workstation/Server, Background GC, LowLatency, etc.).

Cuando se supera un presupuesto (budget) o hay presión del sistema, el GC se inicia (sin intervención del desarrollador).

Ejemplo – incrementar presión (rápido):
```csharp
for (int i = 0; i < 10_000_000; i++)
{
    _ = new byte[64]; // solo asignar, sin retener referencias
}
```

---

## 5) ¿Cómo decide qué liberar? (reachability y raíces)
El GC determina alcanzabilidad desde raíces (roots):
- Stacks de todos los hilos (referencias locales vivas).
- Campos static (raíces globales).
- Manejadores del runtime (handles, finalizer queue).
- Estructuras de contenedores (e.g., un ServiceProvider con singletons/instances retenidas).

El GC traza desde esas raíces y marca como vivos (reachable) todos los objetos alcanzables.  
Los no alcanzables son candidatos a recolección.

Ejemplo – objeto queda sin referencias (se vuelve unreachable):
```csharp
void Foo()
{
    var temp = new byte[1024]; // reachable durante Foo
} // fin del frame -> temp ya no es alcanzable -> candidato a GC
```

---

## 6) ¿Qué pasa durante una colección? (fases del GC)
Secuencia típica (para Gen0/Gen1; Gen2 similar y más costosa):

1. Pausa (Stop-the-world): el CLR suspende los hilos de usuario para garantizar que el heap no cambie durante el marcado/compacción.
2. Escaneo de raíces: examina stacks, estáticos, handles.
3. Marcado: marca objetos alcanzables.
4. Sweep & Compact:
   - Libera memoria de objetos no alcanzables.
   - Compacta (mueve) objetos vivos para eliminar huecos (defragmentar).
   - Promociona sobrevivientes: Gen0 -> Gen1, Gen1 -> Gen2.
5. Reanuda hilos: se actualizan las referencias y continúa la ejecución.

Con Background GC (BGC), parte del proceso ocurre concurrentemente, reduciendo pausas, pero hay pequeñas pausas de coordinación (safepoints).

Ejemplo – minimizar pausas evitando asignaciones vacías:
```csharp
// Evitar:
return new List<int>();        // asigna List + array interno

// Preferir:
return Array.Empty<int>();     // singleton cacheado -> sin asignación
```

---

## 7) Fragmentación: causas y mitigación
Fragmentación = espacios libres dispersos que no pueden usarse eficientemente para nuevas asignaciones contiguas, aumentando el tamaño del heap y la frecuencia de GC.

### 7.1 Tipos relevantes en .NET
- Externa: huecos entre objetos por ciclos de vida disparejos o por objetos pinned que impiden compacción a su alrededor.
- LOH fragmentation: arrays/objetos grandes se liberan dejando huecos grandes en LOH; por defecto LOH no se compacta siempre.

### 7.2 Causas comunes
- Uso intensivo de objetos grandes (>= 85 KB) con ciclos de vida heterogéneos.
- Pines frecuentes: GCHandle.Alloc(obj, GCHandleType.Pinned) o buffers fijados al interoperar.
- Fuertes picos de asignación combinados con retención en listas/colas.

### 7.3 Mitigación
- Evitar pinning prolongado; copiar a un buffer temporal si es posible.
- Pool de buffers: ArrayPool<byte>.Shared.Rent/Return.
- String.Create / Span<T> para minimizar asignaciones.
- LOH compaction on demand:
  ```csharp
  GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
  GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true, compacting: true);
  ```
  LOH se compacta sólo en colecciones completas bloqueantes cuando se solicita.

Ejemplo – pinning que puede fragmentar:
```csharp
var handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
try
{
    // Llamada nativa que requiere memoria fija
}
finally
{
    handle.Free(); // mantener el pin lo mínimo posible
}
```

---

## 8) Generaciones y promociones (Supervivencia)
- Objetos nuevos -> Gen0.
- Si sobreviven a un GC, promueven a Gen1; si vuelven a sobrevivir, Gen2.
- Gen2 se recolecta con menos frecuencia, por eso conviene evitar retener temporalmente objetos que no sean realmente de larga vida (evita "elevar" basura accidentalmente).

Ejemplo – evitar retención innecesaria que promueve basura:
```csharp
static readonly List<byte[]> Cache = new();

void LeakALittle()
{
    Cache.Add(new byte[10_000]); // si esto era temporal, ahora promueve a Gen2
}
```

---

## 9) Pausas del GC y modos de operación
- Workstation GC: pensado para desktop/latencia; pausas cortas.
- Server GC: threads de GC por core; mayor throughput en servidores.
- Background GC: reduce pausas completas con trabajo concurrente.
- Low Latency: GCLatencyMode.SustainedLowLatency reduce colecciones intrusivas (no usar indiscriminadamente).

Ejemplo – ventanas críticas (no recomendado de forma permanente):
```csharp
var old = GCSettings.LatencyMode;
try
{
    GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
    // Sección donde prefieres menos pausas
}
finally
{
    GCSettings.LatencyMode = old;
}
```

---

## 10) DI (Singleton/Scoped/Transient) vs GC (alcanzabilidad)
El GC no entiende "scopes": sólo alcanzabilidad.
- Singleton DI: referenciado por el RootScope del contenedor -> reachable mientras viva el ServiceProvider.
- Scoped DI: referenciado por el scope actual -> al hacer scope.Dispose(), queda sin referencia y el GC puede liberarlo.
- Transient: no almacenado; vive mientras algún objeto/stack lo referencie.

Ejemplo – scoped liberado al cerrar scope:
```csharp
using var scope = provider.CreateScope();
var repo = scope.ServiceProvider.GetRequiredService<IRepository>(); // reachable
// fin del using -> referencias caen -> candidato a GC
```

---

## 11) Buenas prácticas clave
- Reutiliza buffers: ArrayPool<T>; evita new byte[...] en hot paths.
- Para colecciones vacías: Array.Empty<T>() o Enumerable.Empty<T>().
- Evita pinned prolongados; encapsula interop.
- Evita crear LOH innecesariamente (umbral ~ 85 KB); trocea o reutiliza.
- Evita promocionar basura: no retengas temporalidades en singletons o cachés.
- Mide: dotnet-counters, dotnet-trace, dotnet-gcdump, dotMemory.

---

## 12) Apéndice — Métricas útiles (dotnet-counters)
- gc-heap-size, allocated-bytes, allocation-rate
- gen-0/1/2-gc-count, time-in-gc
- loh-size, pinned-objects (según versión)
- cpu-usage, working-set

Ejemplo – recoger 20s de métricas:
```bash
dotnet-counters collect --process-id <PID> --duration 00:00:20 --output gc-metrics.csv
```

---

## 13) Diagrama de secuencia — de asignación a recolección

```mermaid
sequenceDiagram
    autonumber
    participant App as App Thread
    participant CLR as CLR/EE
    participant GC as GC (FG/BG)
    participant Gen0 as Heap Gen0
    participant Gen1 as Heap Gen1
    participant Gen2 as Heap Gen2/LOH
    participant FZT as Finalizer Thread
    participant OS as OS Memory

    App->>CLR: Solicita asignar objeto pequeño
    CLR->>Gen0: Bump pointer (reserva en Gen0)
    Gen0-->>CLR: Referencia a objeto asignado
    CLR-->>App: Devuelve referencia

    App->>App: Ejecuta y crea más objetos (presión de asignación)
    App->>CLR: Más asignaciones (incrementa counters)
    CLR->>GC: Budget superado / señal de presión
    GC->>CLR: Solicita safepoint (preparar pausa)
    CLR->>App: Suspende hilos (Stop-the-world)

    GC->>CLR: Enumera raíces (stacks, estáticos, handles, DI roots)
    GC->>Gen0: Marca alcanzables en Gen0
    GC->>Gen1: Marca alcanzables en Gen1
    GC->>Gen2: Marca alcanzables y LOH

    alt Objetos no alcanzables en Gen0
        GC->>Gen0: Libera memoria de no alcanzables
    end

    GC->>Gen0: Compacta Gen0 (elimina huecos)
    GC->>Gen1: Promueve sobrevivientes de Gen0 a Gen1
    GC->>Gen2: (Opcional) Promueve sobrevivientes de Gen1 a Gen2
    note over Gen2: LOH se recoge con Gen2; compactación sólo si se solicita

    GC->>FZT: Coloca finalizables en cola de finalización
    FZT->>App: Ejecuta finalizadores en background

    GC->>CLR: Actualiza referencias (post-compaction)
    CLR->>App: Reanuda hilos (fin de la pausa)

    App->>CLR: Nuevas asignaciones continúan
    CLR->>OS: (Según presión) Solicitudes/devoluciones de memoria de sistema
```

---

## 14) Referencias
- Garbage Collection: Automatic Memory Management in the Microsoft .NET Framework — docs Microsoft
- .NET GC Performance: generational model, BGC, LOH compaction (docs)
- Improve performance by avoiding allocations — .NET runtime team guidance
- ArrayPool<T>, Span<T>, Memory<T> — APIs para reducir asignaciones
