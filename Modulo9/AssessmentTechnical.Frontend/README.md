# React + TypeScript + Vite

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react) uses [Babel](https://babeljs.io/) (or [oxc](https://oxc.rs) when used in [rolldown-vite](https://vite.dev/guide/rolldown)) for Fast Refresh
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react-swc) uses [SWC](https://swc.rs/) for Fast Refresh

## React Compiler

The React Compiler is not enabled on this template because of its impact on dev & build performances. To add it, see [this documentation](https://react.dev/learn/react-compiler/installation).

## Expanding the ESLint configuration

If you are developing a production application, we recommend updating the configuration to enable type-aware lint rules:

```js
export default defineConfig([
  globalIgnores(['dist']),
  {
    files: ['**/*.{ts,tsx}'],
    extends: [
      // Other configs...

      // Remove tseslint.configs.recommended and replace with this
      tseslint.configs.recommendedTypeChecked,
      // Alternatively, use this for stricter rules
      tseslint.configs.strictTypeChecked,
      // Optionally, add this for stylistic rules
      tseslint.configs.stylisticTypeChecked,

      // Other configs...
    ],
    languageOptions: {
      parserOptions: {
        project: ['./tsconfig.node.json', './tsconfig.app.json'],
        tsconfigRootDir: import.meta.dirname,
      },
      // other options...
    },
  },
])
```

You can also install [eslint-plugin-react-x](https://github.com/Rel1cx/eslint-react/tree/main/packages/plugins/eslint-plugin-react-x) and [eslint-plugin-react-dom](https://github.com/Rel1cx/eslint-react/tree/main/packages/plugins/eslint-plugin-react-dom) for React-specific lint rules:

```js
// eslint.config.js
import reactX from 'eslint-plugin-react-x'
import reactDom from 'eslint-plugin-react-dom'

export default defineConfig([
  globalIgnores(['dist']),
  {
    files: ['**/*.{ts,tsx}'],
    extends: [
      // Other configs...
      // Enable lint rules for React
      reactX.configs['recommended-typescript'],
      // Enable lint rules for React DOM
      reactDom.configs.recommended,
    ],
    languageOptions: {
      parserOptions: {
        project: ['./tsconfig.node.json', './tsconfig.app.json'],
        tsconfigRootDir: import.meta.dirname,
      },
      // other options...
    },
  },
])
```

---

Frontend – ProjectCore
1. Visión General

El frontend de ProjectCore está desarrollado con React + TypeScript, utilizando Vite como herramienta de bundling y desarrollo.
La aplicación consume una API REST protegida mediante JWT, implementando autenticación, gestión de cursos y lecciones bajo un enfoque modular, desacoplado y orientado al dominio.

El objetivo principal del frontend no es solo presentar información, sino orquestar casos de uso del dominio, manteniendo el menor acoplamiento posible con detalles de infraestructura (HTTP, almacenamiento, rutas).

2. Stack Tecnológico

React: Librería principal para la construcción de la UI.

TypeScript: Tipado estático para mayor seguridad, mantenibilidad y autocompletado.

Vite: Bundler rápido y minimalista para desarrollo y build.

Axios: Cliente HTTP centralizado.

JWT: Mecanismo de autenticación stateless.

React Router: Manejo de navegación y rutas protegidas.

3. Arquitectura del Frontend

El proyecto sigue una organización por dominio funcional, no por tipo técnico.
Esto evita estructuras frágiles del tipo components/, services/, pages/ sin contexto de negocio.

Estructura de Carpetas
src/
│
├── api/                 # Infraestructura HTTP compartida
│   └── http.ts          # Cliente Axios centralizado
│
├── auth/                # Dominio de autenticación
│   ├── authApi.ts       # Acceso a endpoints de auth
│   └── LoginPage.tsx    # Caso de uso: Login
│
├── courses/             # Dominio de cursos
│   ├── courseApi.ts     # Acceso a API de cursos
│   ├── courseTypes.ts   # Modelos y contratos
│   ├── courseUtils.ts   # Helpers de dominio
│   └── CoursesPage.tsx  # Casos de uso: CRUD y publicación
│
├── lessons/             # Dominio de lecciones
│   ├── lessonApi.ts
│   ├── lessonTypes.ts
│   └── CourseDetailPage.tsx
│
└── router/              # Ruteo y protección de rutas

Justificación Arquitectónica

Cada carpeta representa un bounded context del frontend.

Las páginas no conocen detalles de Axios ni de headers HTTP.

Los modelos (Types) definen contratos claros con el backend.

La infraestructura (HTTP, routing) está aislada del dominio.

4. Autenticación y Seguridad
Flujo de Login

El usuario envía credenciales.

El backend responde con un JWT.

El token se persiste en localStorage.

El cliente HTTP lo adjunta automáticamente en cada request protegida.