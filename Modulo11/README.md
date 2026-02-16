# 🎬 WatchWi - Plataforma de Streaming (Estilo Netflix)

WatchWi es una aplicación Full Stack de alto rendimiento diseñada bajo una arquitectura escalable, inspirada en plataformas de streaming como Netflix. Este proyecto fue el núcleo del **Módulo 11 (Riwi Training)** para poner en práctica flujos avanzados de **CI/CD** y automatización en la nube.

![Demo de la aplicación](DEMO.gif)

---

## 🚀 Arquitectura del Proyecto

El ecosistema está dividido en dos grandes pilares integrados:

### ⚙️ Backend (`WatchWi-Backend`)

Desarrollado con un enfoque en seguridad y persistencia de datos:

- **Lenguaje:** C# con .NET.
- **ORM:** Entity Framework (EF) Core para la gestión de datos.
- **Base de Datos:** MySQL.
- **Seguridad:** Autenticación y Autorización basada en **JWT** (JSON Web Tokens).
- **Gestión Multimedia:** Integración con **Cloudinary** para el almacenamiento y optimización de imágenes/videos.

### 💻 Frontend (`WatchWi-Frontend`)

Una interfaz moderna, reactiva y tipada:

- **Framework:** **Vue.js** con **TypeScript** para un código robusto y escalable.
- **Estilos:** **Bootstrap** para un diseño responsive.
- **Comunicación:** **Axios** para el consumo eficiente de la API REST.

---

## 🛠️ DevOps & Despliegue (Azure DevOps)

El objetivo principal de este repositorio fue dominar el ciclo de vida de una aplicación mediante herramientas de **Azure DevOps**:

1. **Dockerización:** Creación de archivos `Dockerfile` y `docker-compose` para asegurar la paridad entre los entornos de desarrollo y producción.
2. **Continuous Integration (CI):** Pipeline configurado para compilar el código, validar tipos en TypeScript y restaurar dependencias de NuGet automáticamente con cada *push*.
3. **Continuous Deployment (CD):** Flujo de despliegue continuo configurado para entregar nuevas versiones de manera automatizada.
4. **Gestión de Infraestructura:** Prácticas de despliegue relacionadas con contenedores y servicios de Azure.

---

## 📦 Estructura del Repositorio

```text
├── WatchWi-Backend/     # API REST en .NET 
├── WatchWi-Frontend/    # SPA en Vue.js
├── DEMO.gif             # Vista previa de la aplicación
└── README.md            # Documentación principal
```

---

[![C#](https://img.shields.io/badge/Backend-C%23-blueviolet)](https://learn.microsoft.com/dotnet/csharp/)
[![Vue.js](https://img.shields.io/badge/Frontend-Vue.js-4fc08d)](https://vuejs.org/)
[![Azure DevOps](https://img.shields.io/badge/DevOps-Azure%20DevOps-0078d7)](https://azure.microsoft.com/services/devops/)
[![Docker](https://img.shields.io/badge/Container-Docker-2496ed)](https://www.docker.com/)