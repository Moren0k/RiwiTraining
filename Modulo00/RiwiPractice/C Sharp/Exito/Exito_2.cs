namespace Exito;
public static class Program
{
    public record Producto(int IdProducto, string? Nombre, double Precio); //Representa un producto

    static void Main(string[] args)
    {
        //Crear producto
        var producto1 = new Producto(1, "Nevera", 200);
        var producto2 = new Producto(2, "Licuadora", 150);
        var producto3 = new Producto(3, "Micro", 100);
        var producto4 = new Producto(4, "Infra", 50);

        // Crear lista con Productos
        var productos = new List<Producto> { producto1, producto2, producto3, producto4 };

        //Nuevo producto
        var producto5 = new Producto(5, "Computador", 300);
        //Agregar a la lista
        productos.Add(producto5);

        //Imprimir todo
        foreach (var p in productos)
        {
            Console.WriteLine(p.Nombre);
        }
    }
}