# Proyecto LINQ en C Sharp

Este proyecto es una demostración práctica del uso de **LINQ (Language Integrated Query)** en C#.  
Permite consultar, filtrar, ordenar y relacionar colecciones de objetos en memoria de una manera declarativa y sencilla.

---

## Modelos

El proyecto define tres modelos principales dentro del namespace `LinQ.Models`:

### **Product**

| Propiedad     | Tipo    | Descripción                 |
|---------------|---------|-----------------------------|
| ProductId     | int     | Identificador único del producto |
| ProductName   | string  | Nombre del producto         |
| ProductPrice  | decimal | Precio del producto         |

### **Customer**

| Propiedad     | Tipo    | Descripción                  |
|---------------|---------|------------------------------|
| CustomerId    | int     | Identificador único del cliente |
| CustomerName  | string  | Nombre del cliente           |
| CustomerEmail | string  | Correo electrónico del cliente |

### **Order**

| Propiedad   | Tipo | Descripción                                |
|-------------|------|--------------------------------------------|
| OrderId     | int  | Identificador único de la orden             |
| CustomerId  | int  | Relación con el cliente (`Customer`)        |
| ProductId   | int  | Relación con el producto (`Product`)        |
| Quantity    | int  | Cantidad del producto comprado              |

---

## Funcionalidades implementadas

1. **Filtrar productos por precio**  
   - Productos con precio menor a 1000.  
   - Productos con precio mayor a 1500.  
   - Implementado con:
     - Sintaxis de consulta: `from...where...select`  
     - Sintaxis de métodos: `.Where()`

2. **Mostrar clientes**  
   - Listado completo con LINQ.  
   - Proyección de solo nombres con `.Select()`.  

3. **Ordenar productos por precio**  
   - Orden descendente con `.OrderByDescending()`.  

4. **Validaciones en colecciones**  
   - Verificar si todos los productos cuestan más de 400 (`.All()`).  
   - Verificar que todos los clientes tengan email (`.All()`).  
   - Comprobar si existe un producto por ID (`.Contains()`).  
   - Comprobar si existe un cliente por ID o nombre (`.Contains()`).  

5. **Uniones (JOINS) entre colecciones**  
   - Combinar `Orders`, `Customers` y `Products`.  
   - Mostrar resultados con:
     - Número de orden  
     - Nombre del cliente  
     - Nombre del producto  
     - Cantidad  
     - Total calculado (cantidad × precio)  

   **Ejemplo de salida:**  

   ```csharp
   Kevin compró 2x Shampoo = 1000
   Luisa compró 4x Cepillo = 10000
   David compró 3x Agua = 6000
   ```

---

## Ejecución

1. Clonar o descargar el proyecto.  
2. Abrir en **Visual Studio** o **VS Code**.  
3. Ejecutar con:

   ```bash
   dotnet run
   ```

4. Los resultados se mostrarán en la consola.  

---

## Propósito

Este proyecto tiene fines **educativos** y busca mostrar ejemplos claros de cómo usar **LINQ en C#** para:

- Filtrar datos
- Seleccionar campos específicos  
- Ordenar colecciones  
- Validar condiciones  
- Hacer uniones entre colecciones relacionadas
