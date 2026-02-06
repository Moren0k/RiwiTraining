using Tienda.Models;

namespace Tienda;

public static class Program
{
    public static void Main(string[] args)
    {
        var repo = new RepoProducto();
        
        repo.Agregar((new Producto{Nombre = "papas",Precio = 20}));
        repo.Agregar((new Producto{Nombre = "alfajor",Precio = 30}));
        repo.Agregar((new Producto{Nombre = "chicle",Precio = 40}));
        
        Console.WriteLine("Lista Privada");
        foreach (var item in repo.Mostrar())
        {
            Console.WriteLine($"Producto: [{item.Nombre}], Precio: [{item.Precio}]");
        }

        Console.WriteLine("Lista Publica");
        foreach (var item in repo.Productos)
        {
            Console.WriteLine($"Producto: [{item.Nombre}], Precio: [{item.Precio}]");
        }
    }
}