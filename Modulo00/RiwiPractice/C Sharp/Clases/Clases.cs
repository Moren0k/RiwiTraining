namespace Clases;
public class Program
{
    public class Producto //Define un Producto
    {
        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public double Precio { get; set; }
    }

    public class Cliente //Define un Cliente
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public Producto? Producto { get; set; }
    }
    static void Main(string[] args)
    {
        //Crea 4 productos (ej: Laptop, Celular, Libro, Audífonos).
        var producto1 = new Producto { Codigo = 1, Nombre = "Laptop", Precio = 800 };
        var producto2 = new Producto { Codigo = 1, Nombre = "Celular", Precio = 250 };
        var producto3 = new Producto { Codigo = 1, Nombre = "Libro", Precio = 50 };
        var producto4 = new Producto { Codigo = 1, Nombre = "Audifonos", Precio = 100 };
        
        //Crea 2 clientes, y a cada cliente asígnale algunos productos en su lista.
        var cliente1 = new Cliente { Id = 1, Nombre = "Kevin", Edad = 20 , Producto = producto1 };
        var cliente2 = new Cliente { Id = 2, Nombre = "Santiago", Edad = 25 , Producto = producto4 };
        
        //Crea una lista de clientes (List<Cliente>) y agrega a los clientes creados.
        List<Cliente> clientes = new List<Cliente>{cliente1, cliente2};
        
        //Recorre la lista de clientes con foreach.
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Hola soy : {cliente.Nombre} tengo {cliente.Edad}Años y compre: {cliente.Producto?.Nombre}");
        }
    }
}