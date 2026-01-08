namespace Exito;
public static class Program
{
    public class Producto //Representa un producto
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; init; }
        public double Precio { get; set; }
    }

    static void Main(string[] args)
    {
        //Crear producto
        var producto1 = new Producto { IdProducto = 1, Nombre = "Nevera", Precio = 200 };
        var producto2 = new Producto { IdProducto = 2, Nombre = "Licuadora", Precio = 150 };
        var producto3 = new Producto { IdProducto = 3, Nombre = "Micro", Precio = 100 };
        var producto4 = new Producto { IdProducto = 4, Nombre = "Infra", Precio = 50 };

        //Crear lista con Productos
        List<Producto> productos = new List<Producto>{producto1, producto2, producto3, producto4};
        
        //Nuevo producto
        var producto5 = new Producto { IdProducto = 5, Nombre = "Computador", Precio = 300 };
        //Agregar a la lista
        productos.Add(producto5);
        
        //Imprimir todo
        foreach (var p in productos)
        {
            Console.WriteLine(p.Nombre);
        }
    }
}