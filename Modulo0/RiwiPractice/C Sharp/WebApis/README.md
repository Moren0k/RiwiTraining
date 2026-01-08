# Creación de una solución con estructura DDD en CSharp

Este documento describe paso a paso cómo crear una solución **.NET** con estructura basada en **Domain-Driven Design (DDD)**, utilizando la línea de comandos.

---

## 1. Crear carpeta del proyecto

```bash
mkdir apiWeb
cd apiWeb
```

---

## 2. Crear la solución principal

```bash
dotnet new sln -n solution
```

> Crea un archivo de solución (`solution.sln`) que agrupará todos los proyectos.

---

## 3. Crear los proyectos según las capas DDD

### API (Capa de Presentación)

```bash
dotnet new webapi -n apiWeb.Api
```

> Genera una **Web API ASP.NET Core**, punto de entrada de la aplicación.

---

### Application (Capa de Aplicación)

```bash
dotnet new classlib -n apiWeb.Application
```

> Contiene los **casos de uso**, la **lógica de aplicación** y la **orquestación** entre el dominio e infraestructura.

---

### Domain (Capa de Dominio)

```bash
dotnet new classlib -n apiWeb.Domain
```

> Define las **entidades**, **agregados**, **value objects**, **interfaces** y **servicios de dominio**.

---

### Infrastructure (Capa de Infraestructura)

```bash
dotnet new classlib -n apiWeb.Infrastructure
```

> Contiene las implementaciones concretas de persistencia, acceso a datos, HTTP clients, etc.

---

![Diagrama de capas DDD](docs/PLJ1RXen4BtxAqRaGYMIg5BL0uSgQO0KgKbGeAqgzJ9uXyM9rrxPNfAqwhKVqB_eeQTy0d_IB-dOky06EB1hxxoPDs-UVUO3kb0LMWGLDC7G1rV9K3c4mM00PE3aUZW3QGtG7HMbjXuo0hb-pbHkXV3tofJei80IvJtcD0rFdCQH36XoJQq0lyJCFYYJmmArRt-PCpHtjZBPXTNMmT4e_GwJpoB7aJLXghuJl7xRYjXMt7r-8qI3WywmA1.png)

---

## 4. Agregar los proyectos a la solución

```bash
dotnet sln add apiWeb.Api/
dotnet sln add apiWeb.Application/
dotnet sln add apiWeb.Domain/
dotnet sln add apiWeb.Infrastructure/
```

---

## 5. Establecer las referencias entre capas

```bash
dotnet add apiWeb.Api reference apiWeb.Application
dotnet add apiWeb.Application reference apiWeb.Domain
dotnet add apiWeb.Infrastructure reference apiWeb.Application
```

> Esto mantiene las dependencias limpias según las reglas de DDD.
>
> - La **API** depende de **Application**.
> - **Application** depende de **Domain**.  
> - **Infrastructure** puede depender de **Application** y **Domain**.

![Diagrama de dependencias entre proyectos](docs/SoWkIImgAStDuIf8JCvEJ4zLK7B9pqtCp5DIgEQgvKA8EXOKv6Gc9vPavcD8UUQb5IKMbnIL9fUK5gLYQ0pmX0e1MGgwkdOAI4OfM2aefQGMfEQbf2gaf2fn8Kk1b4BSWguArK92PZe0MI0F0W00.png)

---

## 6. Restaurar dependencias y verificar

```bash
dotnet restore
dotnet build
```

> Verifica que todos los proyectos estén correctamente enlazados y compilados.

---

## Estructura resultante

```bash
apiWeb/
│
├── solution.sln
├── apiWeb.Api/
├── apiWeb.Application/
├── apiWeb.Domain/
└── apiWeb.Infrastructure/
```

---

## Ejemplo de como funciona DDD

![Estructura de la solución DDD](docs/image.png)

---

## Resultado

Solución .NET lista para implementar una arquitectura basada en DDD, con separación clara entre capas de dominio, aplicación, infraestructura y presentación.

---
