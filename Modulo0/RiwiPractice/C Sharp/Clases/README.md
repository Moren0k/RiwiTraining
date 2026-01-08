# Gestión de Clientes y Productos en CSharp

## Enunciado

Una tienda necesita un programa sencillo para gestionar clientes y los productos que cada uno compra.

---

## Paso 1: Crear las clases

### Clase Producto

- `Codigo` (int)
- `Nombre` (string)
- `Precio` (double)

### Clase Cliente

- `Id` (int)
- `Nombre` (string)
- `Edad` (int)
- `Productos` (Lista de productos → `List<Producto>`)

---

## Paso 2: Crear objetos

En el `Main`:

1. Crea **4 productos** (ejemplo: Laptop, Celular, Libro, Audífonos).  
2. Crea **2 clientes**, y a cada cliente asígnale algunos productos en su lista.

---

## Paso 3: Guardar en una colección

1. Crea una lista de clientes (`List<Cliente>`) y agrega a los clientes creados.  
2. Recorre la lista de clientes con `foreach`:  
   - Por cada cliente, imprime su información.  
   - Luego, recorre su lista de productos y muéstralos también.

---

Con este ejercicio practicas:  

- Creación de **clases** en C#.  
- Uso de **listas genéricas (`List<T>`)**.  
- **Recorridos con foreach** anidados.
