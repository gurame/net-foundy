# EntryTrace

Let's how the code is compiled and traduced into IL and then into machine code.

## Compiling and Tracing

To compile the code and generate the IL (Intermediate Language) code, you can use the following command:

```bash
dotnet build -c Debug
```

This will compile the code in Debug mode, which includes additional debugging information.
To view the IL code, you can use the `ildasm` tool that comes with the .NET SDK. Run the following command:

To install `ildasm`, you can use the following command:

```bash
# For NetCore 3.0
dotnet tool install -g dotnet-ildasm
# For .NET 5.0 and later
dotnet tool install --global ilspycmd
```

Then, you can run `ilspycmd` on the compiled DLL file:

```bash
# For .NET 8.0
DOTNET_ROOT=/opt/homebrew/Cellar/dotnet@8/8.0.120/libexec ilspycmd -il bin/Debug/net9.0/EntryTrace.Console.dll > EntryTrace.Console.il
```

This will generate a file named `EntryTrace.Console.il` containing the IL code.

Now, let's execute the program with tracing enabled. You can use the following command:

```bash
dotnet run -c Debug
```

To see the native code at the momento of JIT, run the following command:

```bash
DOTNET_JitDisasm="*Main*" dotnet run -c Release
```

To see the native code at the momento of AOT, run the following command:

```bash
otool -tvV bin/Release/net9.0/osx-arm64/native/EntryTrace.Console | less
```

### Summary

📌 Resumen — De C# a Ejecución Nativa
1. .dll vs .exe en .NET

.exe (en .NET Framework clásico, Windows-only):

Ejecutable administrado con un encabezado PE.

El SO lo carga y activa el CLR instalado.

Contiene punto de entrada (Main).

.dll:

Biblioteca compartida, sin punto de entrada propio.

Usada como dependencia por otros proyectos.

👉 En .NET Core/.NET moderno (cross-platform):

El compilador produce por defecto un .dll portable.

Se ejecuta con el host dotnet:

dotnet MiApp.dll


También puedes publicar en self-contained → se genera un .exe (Windows) o binario ELF/Mach-O (Linux/macOS) con runtime incluido.

2. OutputType en csproj

<OutputType>Exe</OutputType>: el ensamblado tendrá un punto de entrada (Main) y podrá ejecutarse.

<OutputType>Library</OutputType>: se genera solo un .dll (sin Main).

3. El proceso de compilación

Código C# (.cs) → compilador Roslyn (csc.dll).

Se genera IL (Intermediate Language) + metadata.

Se guarda en un ensamblado (.dll o .exe administrado).

Se crea un .pdb con símbolos de depuración (para debugging/stacktraces).

👉 El .dll todavía no es nativo, requiere un runtime para ejecutarse.

4. El host en .NET

Es el puente entre el SO y el CLR/CoreCLR.

Tipos de host:

.exe administrado en .NET Framework.

dotnet (CLI) en .NET Core/5+/6+/7+/8+/9.

Ejecutable nativo self-contained (publicado con runtime incluido).

5. Ejecución

Cuando corres dotnet run o dotnet MiApp.dll:

El host crea el proceso.

Se carga CoreCLR (runtime).

El runtime busca el Main.

Cada método se JITea la primera vez que se llama.

6. IL → Lenguaje máquina

El JIT (RyuJIT) traduce IL a código nativo (x64, ARM64…).

Eso es lo que la CPU ejecuta.

Se cachea en memoria: la siguiente vez no se recompila.

👉 Es correcto hablar de “lenguaje máquina” porque son instrucciones reales de CPU.

7. JIT vs AOT

JIT (Just-In-Time):

Traducción en runtime, método a método.

Permite optimizaciones dinámicas (tiered compilation, PGO).

Variabilidad entre ejecuciones.

AOT (Ahead-Of-Time / NativeAOT):

Compilación a nativo en build/publish.

Produce un ejecutable auto-suficiente.

Arranque más rápido, binario fijo.

8. Herramientas de inspección

IL (Intermediate Language):

ilspycmd (CLI de ILSpy).

Requiere tener instalado el runtime para el que fue compilada la tool.

JIT (ensamblador generado en runtime):

DOTNET_JitDisasm="*Main*" dotnet run -c Release
→ imprime el ASM generado por el JIT al ejecutar métodos.

AOT (binarios nativos):

macOS: otool -tvV MiApp para ver el código ensamblador del ejecutable Mach-O.

Windows/Linux: objdump, lldb, o herramientas de profiling.

9. .pdb

Archivos de símbolos de depuración.

Permiten mapear IL → código fuente en debugging y stack traces.

En .NET moderno se usan Portable PDBs (cross-platform).

🔑 Diferencia final: JIT vs AOT ASM
Aspecto	JIT (DOTNET_JitDisasm)	AOT (otool en binario publicado)
Cuándo	En runtime, al invocar métodos.	En build, durante publish.
Dónde vive	En memoria del proceso.	En el ejecutable nativo en disco.
Estabilidad	Puede cambiar (tiered, PGO).	Fijo, determinístico.
Uso	Diagnóstico de rendimiento en vivo.	Auditoría del binario final.

✅ En resumen:

En .NET moderno, compilar genera un .dll (IL + metadata).

El host (dotnet o un ejecutable self-contained) arranca el proceso y carga el runtime.

El JIT traduce IL a nativo en runtime (lenguaje máquina).

Con NativeAOT puedes obtener directamente un binario nativo, que luego puedes inspeccionar con herramientas como otool.

Para depuración, están los .pdb y las herramientas como ilspycmd (IL) y DOTNET_JitDisasm (ASM en runtime).
