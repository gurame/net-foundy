# ASP.NET Core – Request Lifecycle

## 0) Arranque del host
**[Generic Host / WebApplication] → Inicializa la app**  
Configura DI, logging, configuración, y construye el pipeline de middlewares en `Program.cs`.

---

## 1) Recepción de conexión
**[Kestrel] → Acepta conexión TCP/HTTP(S)**  
- Lee bytes del socket y parsea método, ruta, headers, etc.  
- Crea/obtiene de pool un **`DefaultHttpContext`** con `Request`, `Response`, `Features`.

*Claves*  
- `HttpContext` es **scoped al request** (no ligado a un hilo).  
- `IFeatureCollection` expone capacidades (HTTP/1.1, HTTP/2, TLS, WebSockets, etc.).  

---

## 2) Inyección de servicios por request
**[DI / IServiceScopeFactory] → Crea scope del request**  
- Pone `RequestServices` en `HttpContext` con el **scope per-request**.  
- A partir de aquí, resoluciones via DI salen del scope del request.

---

## 3) Entrada al pipeline
**[Middleware Pipeline] → Orquesta el flujo**  
- El `HttpContext` entra al **primer middleware**.  
- Cada middleware puede:
  - Leer/editar `Request/Response`.  
  - Registrar telemetría.  
  - **Cortar** o **pasar** al siguiente (`await next(context)`).

*Middlewares típicos (orden aproximado)*  
- Error/Exception Handling (`UseDeveloperExceptionPage`, custom).  
- HTTPS Redirection, HSTS, ForwardedHeaders, StaticFiles.  
- Routing (`UseRouting`).  
- CORS, Authentication, Authorization.  
- Endpoint (`UseEndpoints`).  

---

## 4) Resolución de endpoint
**[Routing] → Selecciona endpoint**  
- Usa `EndpointDataSource` (rutas de Minimal APIs/MVC/Razor).  
- Escribe en `HttpContext.Endpoint` y sus `Metadata`.

*Claves*  
- No ejecuta aún el handler; **solo fija el endpoint**.  
- `HttpContext.GetEndpoint()` devuelve metadatos (p.ej. `[Authorize]`, `Produces`).  

---

## 5) Autenticación y autorización
**[AuthenticationMiddleware] → Establece `HttpContext.User`**  
- Llama a handlers (Cookies, JWT, etc.).

**[AuthorizationMiddleware] → Enforce policies**  
- Lee `Endpoint.Metadata`.  
- Si falla, responde 401/403 y corta ejecución.

---

## 6) Ejecución del endpoint
**[EndpointMiddleware] → Invoca el handler**  
- Según tipo: **Minimal API**, **MVC**, **Razor Pages**, etc.  

### a) Minimal API
- **RequestDelegateFactory (RDF)** genera el delegado.  
- Hace param binding (route, query, header, form, body, services).  
- Ejecuta el handler async.  
- Devuelve un `IResult`.  

### b) MVC Controller
1. Routing fija `ActionDescriptor`.  
2. Controller Factory crea instancia.  
3. **Model Binding** (IModelBinder, IValueProvider, InputFormatters).  
4. **Validación** con DataAnnotations/FluentValidation → `ModelState`.  
5. **Filters** (Authorization → Resource → Action → Exception/Result).  
6. Acción ejecutada.  
7. **Result Execution**: negotiation + formatters / View engine.  

### c) Razor Pages
1. Routing fija `PageActionDescriptor`.  
2. PageFactory crea `PageModel`.  
3. **Model Binding** a propiedades/handlers.  
4. **Validación** (`ModelState`).  
5. **Filters** (mismo pipeline que MVC).  
6. Handler ejecutado.  
7. Result Execution (PageResult, Redirect, Json, View).  

---

## 7) Trabajo asíncrono y thread hopping
**[async/await + TaskScheduler] → Gestiona continuaciones**  
- `await` libera el hilo.  
- Continuación puede ejecutarse en otro hilo del ThreadPool.  
- El state machine del compilador captura `HttpContext` como campo.  

*Claves*  
- **No hay SynchronizationContext** en ASP.NET Core.  
- `ConfigureAwait` no cambia comportamiento.  

---

## 8) Escritura de la respuesta
**[Kestrel + Output Formatters] → Serializa y envía**  
- Escribe status, headers y body.  
- Usa JSON/Text formatters o Razor View Engine.  
- Middlewares de salida: compresión, caching, logging.  

---

## 9) Finalización del request
**[Kestrel] → Completa y recicla**  
- Flushea response.  
- Ejecuta `Response.OnStarting` / `OnCompleted`.  
- Dispose del scope DI.  
- Recicla HttpContext al pool.  

---

# Cheatsheet (Componentes ↔ Función)

- **Kestrel**: sockets, parseo, serialización, pooling.  
- **Middleware Pipeline**: orquesta request/response.  
- **Routing**: resuelve endpoint y metadatos.  
- **Authentication/Authorization**: `User` y policies.  
- **EndpointMiddleware**: ejecuta handler.  
- **Model Binding**: vincula parámetros.  
- **Validación**: valida modelos.  
- **Filters**: cross-cutting (MVC/Pages).  
- **Output Formatting**: serialización.  
- **RazorViewEngine**: render HTML.  
- **TaskScheduler**: continuaciones async.  
- **DI Scope**: RequestServices.  
- **Observabilidad**: logging, OTEL.  
