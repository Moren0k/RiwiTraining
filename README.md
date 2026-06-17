# Riwi Training — Fullstack & Software Architecture Journey

Repositorio central de aprendizaje durante el entrenamiento intensivo en Riwi.  
Documentación de mi evolución desde fundamentos de lógica hasta arquitecturas empresariales complejas.

> "Building scalable solutions with clean code and solid architecture."

---

## Estructura

```
Modulo##/
  Modulo##_Semana#/
    M##S#.{formato}
    README.md
```

---

## Módulos

| Módulo | Tecnologías | Descripción |
| --- | --- | --- |
| [Modulo00](./Modulo00/) | Python · C# · JS · SQL · NoSQL | Fundamentos de múltiples lenguajes y primeras APIs REST |
| [Modulo01](./Modulo01/) | Python | Lógica de programación, algoritmos y resolución de problemas |
| [Modulo02](./Modulo02/) | HTML · CSS | Diseño web, portafolio personal, modelo de caja y animaciones |
| [Modulo03](./Modulo03/) | JavaScript | Programación web interactiva, DOM, funciones y validaciones |
| [Modulo04](./Modulo04/) | MySQL | Diseño de bases de datos relacionales, normalización y modelos ER |
| [Modulo05](./Modulo05/) | IA | Detector Orbis — clasificación automática con inteligencia artificial |
| [Modulo06](./Modulo06/) | C# | Programación orientada a objetos, LINQ, CRUD en memoria y UML |
| [Modulo07](./Modulo07/) | .NET 8 · DDD · EF Core | APIs RESTful con Domain-Driven Design y pruebas xUnit |
| [Modulo08](./Modulo08/) | Next.js · React · TypeScript | Plataforma fullstack de renta de vehículos con bot IA |
| [Modulo09](./Modulo09/) | .NET 8 · Clean Architecture | API REST con Clean Architecture, JWT y pruebas xUnit |
| [Modulo10](./Modulo10/) | Vue 3 · TypeScript · .NET 8 | Fullstack tipado con Docker, Clean Architecture y Cloudinary |
| [Modulo11](./Modulo11/) | Vue.js · .NET · Docker · Azure DevOps | Plataforma de streaming con CI/CD automatizado |

---

## Proyectos Destacados

### WatchWi — Plataforma de Streaming

[Ir](./Modulo11/) · `Vue.js` `TypeScript` `C#/.NET` `MySQL` `Docker` `Azure DevOps` `Cloudinary`

- Pipeline **CI/CD en Azure DevOps** que compila, valida tipos TypeScript y restaura NuGet en cada push
- Dockerización con `docker-compose` para paridad entre entornos de desarrollo y producción
- Autenticación con **JWT** e integración con **Cloudinary** para gestión de multimedia

---

### ProjectCore — API REST con Clean Architecture

[Ir](./Modulo09/) · `.NET 8` `EF Core` `MySQL` `JWT` `ASP.NET Identity` `xUnit` `FluentAssertions`

- Patrón **Aggregate Root** en `Course` con control total del ciclo de vida de lecciones
- Dominio sin dependencias externas — separación estricta de capas
- **Soft Delete**, Seed automático y middleware global de errores con respuestas JSON consistentes
- Pruebas unitarias de dominio con **xUnit + FluentAssertions** aisladas de EF Core

---

### SistemaGestión — API RESTful con DDD

[Ir](./Modulo07/) · `.NET 8` `Domain-Driven Design` `EF Core` `MySQL` `Swagger` `xUnit` `Docker`

- Cuatro capas independientes: Api → Application → Domain → Infrastructure
- Repositorios genéricos y específicos con inyección de dependencias entre capas
- Relaciones **1:N y M:M** con integridad referencial gestionadas con EF Core
- Endpoints documentados con Swagger y cubiertos con pruebas xUnit

---

### Vue + TypeScript Fullstack

[Ir](./Modulo10/) · `Vue 3` `Composition API` `TypeScript` `.NET 8` `Docker` `Cloudinary` `JWT`

- Composition API con `defineProps<T>()`, `ref<T>()` y servicios como clases estáticas en Axios
- Interceptores automáticos de JWT para inyección de tokens en cada petición
- DTOs como interfaces TypeScript que replican los contratos del backend
- Gestión de roles **Admin/User** con rutas protegidas y Docker Compose

---

## Proyectos Integradores

### SomosRentWi — Renta de Vehículos + Asistente IA

[Ir](./Modulo08/)

`C#/.NET 8` `Clean Architecture` `EF Core` `MySQL (Aiven)` `JWT` `Cloudinary` `Docker` `Railway` `Next.js` `TypeScript` `Mercado Pago` `Google Gemini AI` `Telegram.Bot SDK`

Plataforma para digitalizar el alquiler vehicular en Colombia. Tres sistemas integrados:

**Backend — SomosRentWi API**
- Clean Architecture en cuatro capas (Api, Application, Domain, Infrastructure)
- Autenticación diferenciada por rol: Admin · Empresa · Cliente con JWT
- Ciclo de vida de alquileres: Pendiente → En Progreso → Completado / Con Incidencias
- Verificación documental (cédula, licencia, selfie) almacenada en Cloudinary
- Precios y depósitos calculados dinámicamente, validación de archivos por tipo MIME
- Despliegue con Docker en Railway, base de datos MySQL en la nube (Aiven)

**Frontend — Carlend**
- Next.js con TypeScript, catálogo con filtros, flujo de renta y dashboards por rol
- Suscripciones empresariales con pagos via Mercado Pago (Basic · Premium · Enterprise)

**Asistente IA — SmartRent Bot**
- Bot de Telegram en C# con Telegram.Bot SDK
- Google Gemini AI para búsqueda conversacional de vehículos en lenguaje natural
- Sesiones concurrentes por usuario con `ConcurrentDictionary`
- Consulta la API en tiempo real para mostrar disponibilidad actual

---

## Contacto

[LinkedIn](https://www.linkedin.com/in/jhoskevinagudelomoreno/) · Email: jhoskevinagudelomoreno@gmail.com

---
