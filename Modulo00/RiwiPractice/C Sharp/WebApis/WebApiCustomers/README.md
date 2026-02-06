# WebApiCustomers — Proyecto simple de ejemplo

Este repositorio contiene una Web API mínima en .NET 8 para gestionar "Products" y "Customers" y una pequeña interfaz estática para probar los endpoints.

## Qué hace

- Provee endpoints CRUD in-memory para Productos y Clientes.
- No usa base de datos: los datos se almacenan en listas en memoria (se pierden al parar la aplicación).
- Incluye una interfaz web simple (`Customers.Front`) que consume la API usando fetch.

## Modelos

### Customer

- `Id` (long)
- `Name` (string)
- `LastName` (string)
- `Email` (string)

### Product

- `Id` (long)
- `Name` (string)
- `Description` (string)
- `Price` (decimal)

Las clases están en `Customers.Domain/Models`.

## Endpoints principales

Rutas definidas en `Customers.Api/Program.cs` (HTTP):

- Products

- GET  `/getProduct` — listar productos
- POST `/addProduct` — agregar producto (body JSON)
- PATCH `/updateProduct/{id}` — editar producto (body JSON)
- DELETE `/deleteProduct/{id}` — eliminar producto

- Customers

- GET  `/getCustomer` — listar clientes
- POST `/addCustomer` — agregar cliente (body JSON)
- PATCH `/updateCustomer/{id}` — editar cliente (body JSON)
- DELETE `/deleteCustomer/{id}` — eliminar cliente

Swagger está habilitado en entorno de desarrollo.

## Cómo ejecutar (rápido)

1. Asegúrate de tener .NET 8 SDK instalado.
2. Abrir una terminal en la raíz del repo y ejecutar:

```bash
dotnet run --project Customers.Api/Customers.Api.csproj
```

3. Por defecto la API se sirve en el puerto configurado por Kestrel (revisa la salida de `dotnet run`).

4. Abrir el panel web para probar la API (opcional):

- Abrir `Customers.Front/index.html` en el navegador (puedes abrir el archivo localmente) y ajustar `baseUrl` en `script.js` al puerto donde corre la API (por defecto en este proyecto el script usa `http://localhost:5009`).

## Notas rápidas

- Los servicios `ProductService` y `CustomersServices` usan listas en memoria y están registrados como `Singleton` en `Program.cs`.
- No hay validaciones ni persistencia.

## Estructura relevante

- `Customers.Api/` — punto de entrada, endpoints y configuración.
- `Customers.Application/Services` — `ProductService`, `CustomersServices` (lógica CRUD en memoria).
- `Customers.Domain/Models` — `Product.cs`, `Customer.cs`.
- `Customers.Front/` — frontend estático (HTML + JS) para probar la API.

---
