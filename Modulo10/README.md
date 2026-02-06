# Módulo 10 — Vue + TypeScript

Este módulo representa una aplicación full-stack de gestión de usuarios y activos multimedia, integrando un frontend moderno basado en **Vue 3** con un backend robusto en **.NET 8** siguiendo los principios de Clean Architecture.

## Resumen de la App

La aplicación permite la autenticación de usuarios (Login/Register), la gestión administrativa de perfiles (Listado, eliminación y cambio de roles) y el manejo de imágenes a través de integración con servicios externos (Cloudinary). El sistema implementa seguridad basada en **JWT** y tipado estricto en ambos extremos.

---

## Tech Stack

### Frontend

- **Framework:** Vue 3.5.26 (Composition API)
- **Lenguaje:** TypeScript 5.9.3
- **Build Tool:** Vite (Beta)
- **Routing:** Vue Router 4.6.4
- **HTTP Client:** Axios 1.13.2
- **Tooling:** ESLint, Prettier, Vue-TSC

### Backend

- **Framework:** .NET 8.0 (ASP.NET Core Web API)
- **Arquitectura:** Clean Architecture (API, Application, Domain, Infrastructure)
- **Persistencia:** Entity Framework Core (MySQL)
- **Seguridad:** JWT Bearer Authentication
- **Servicios Externos:** Cloudinary (Gestión de imágenes)
- **Contenedores:** Docker & Docker Compose

---

## Arquitectura y Estructura del Proyecto

```text
Modulo10/
├── ApiTest/                  # Backend (.NET 8)
│   ├── src/
│   │   ├── ApiTest.Api/      # Controllers y Configuración EntryPoint
│   │   ├── ApiTest.Application/ # Lógica de Negocio y DTOs
│   │   ├── ApiTest.Domain/      # Entidades Core
│   │   └── ApiTest.Infrastructure/ # Persistencia y Proveedores Externos
│   ├── compose.yaml          # Orquestación de contenedores
│   └── Dockerfile            # Configuración de imagen de la API
└── ApiTestFrontend/          # Frontend (Vue 3 + TS)
    ├── src/
    │   ├── api/              # Configuración de Axios
    │   ├── components/       # Componentes reutilizables
    │   ├── models/           # Interfaces y Types de TypeScript
    │   ├── router/           # Definición de rutas
    │   ├── services/         # Clases de consumo de API
    │   └── views/            # Páginas principales (Login, Admin, User)
    └── vite.config.ts        # Configuración de Vite
```

---

## Frontend (Vue + TS)

### Estructura y Patrones

- **Views:** Organizadas por dominio (`auth`, `admin`, `user`).
- **Servicios:** Implementados como clases estáticas (ej: `AuthService`, `AdminService`) que encapsulan las llamadas a Axios.
- **Modelos:** Se utilizan interfaces nativas de TS para asegurar que la data consumida del backend coincida con la estructura esperada.

### Tipado (TypeScript)

- **Props y Emits:** Uso de macros `defineProps` y `defineEmits` con interfaces.
- **Estado Reactivo:** Uso de `ref<T>()` y `reactive<T>()` para tipar el estado local de los componentes.
- **DTOs:** Reflejados en la carpeta `src/models/`, asegurando contratos claros entre front y back.

### Routing y Estado

- **Vue Router:** Maneja la navegación SPA. Rutas definidas: `/login`, `/register`, `/user`, `/admin`.
- **LocalStorage:** Se utiliza para persistir el `auth_token` y el `user_role` para validaciones de visualización en cliente.

---

## Backend (.NET 8)

El backend expone una REST API organizada en controladores especializados:

| Método | Ruta | Descripción | Request / Response |
| :--- | :--- | :--- | :--- |
| POST | `api/auth/login` | Inicio de sesión | `LoginRequestDto` -> `AuthResponse` |
| POST | `api/auth/register` | Registro de nuevo usuario | `RegisterRequestDto` -> `AuthResponse` |
| GET | `api/users` | Listado de usuarios (Admin) | Requiere Rol: Admin |
| GET | `api/users/{id}` | Detalle de usuario (Admin) | Requiere Rol: Admin |
| DELETE| `api/users/{id}` | Eliminar usuario (Admin) | Requiere Rol: Admin |
| PATCH | `api/users/{id}/role`| Cambiar rol (Admin) | `ChangeUserRoleRequest` |
| POST | `api/images/upload` | Subir imagen a Cloudinary | `multipart/form-data` |
| GET | `api/images` | Listar imágenes | Lista de URLs persistidas |
| GET | `checks/db` | Health check de Base de Datos | Status de conectividad |

---

## Cómo ejecutar localmente

### Requisitos Previos

- Node.js (v20 o superior)
- .NET 8 SDK
- Docker & Docker Compose
- Herramienta para MySQL (opcional, para visualización)

### Backend

1. Ir a la carpeta `ApiTest/`.
2. Crear un archivo `.env` basado en `.env.example` con tus credenciales de DB y Cloudinary.
3. Levantar la infraestructura:

   ```bash
   docker compose up -d
   ```

4. Ejecutar la migración de base de datos (si aplica) o correr por CLI:

   ```bash
   dotnet run --project src/ApiTest.Api/ApiTest.Api.csproj
   ```

### Frontend

1. Ir a la carpeta `ApiTestFrontend/`.
2. Crear un archivo `.env` con la variable `VITE_API_URL`.
3. Instalar dependencias:

   ```bash
   npm install
   ```

4. Iniciar servidor de desarrollo:

   ```bash
   npm run dev
   ```

---

## Scripts útiles (Frontend)

- `npm run dev`: Inicia el servidor de desarrollo Vite.
- `npm run build`: Compila y minifica para producción.
- `npm run type-check`: Ejecuta verificaciones de tipos mediante `vue-tsc`.
- `npm run preview`: Previsualiza la build de producción localmente.

---

## Troubleshooting

- **CORS:** La API está configurada para permitir todos los orígenes (`AllowAll`), pero asegúrate de que la URL en el frontend coincida con el puerto del backend (ej: `http://localhost:5031`).
- **Auth Token:** Si las peticiones de Admin fallan, limpia el `localStorage` y vuelve a iniciar sesión para regenerar el token JWT.
- **Configuración .env:** El backend carga el `.env` desde la raíz en entornos de Desarrollo (`builder.Environment.IsDevelopment()`).

---

## Notas del Módulo

En este módulo se profundizó en:

1. **Tipado avanzado en Vue:** Implementación de interfaces para respuestas complejas del servidor.
2. **Clean Architecture:** Separación estricta de responsabilidades entre el core del negocio y la infraestructura externa.
3. **Seguridad JWT:** Implementación de interceptores en Axios para inyección automática de tokens.
4. **Manejo de Archivos:** Integración de carga de imágenes vía multipart hacia almacenamiento en la nube.
