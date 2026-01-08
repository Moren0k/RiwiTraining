namespace Clases;
public class Program
{
    public record Productos2 (int Codigo, string Nombre, double Precio);//Define un producto Usando record
    public record Cliente2 (int Id, string Nombre, int Edad, Productos2 Producto2);//Define un producto Usando record
    
    static void Main(string[] args)
    {
        //Crea 4 productos (ej: Laptop, Celular, Libro, Audífonos).
        var producto1 = new Productos2(1, "Laptop", 800);
        var producto2 = new Productos2(2, "Celular", 250);
        var producto3 = new Productos2(3, "Libro", 20);
        var producto4 = new Productos2(4, "Audifonos", 100);
        
        //Crea 2 clientes, y a cada cliente asígnale algunos productos en su lista.
        var cliente1 = new Cliente2(1, "Kevin", 20, producto2);
        var cliente2 = new Cliente2(1, "Andres", 28, producto3);
        
        //Crea una lista de clientes (List<Cliente>) y agrega a los clientes creados.
        var ventas = new List<Cliente2> { cliente1, cliente2 };   

        //Recorre la lista de clientes con foreach.
        foreach (var cliente in ventas)
        {
            Console.WriteLine($"ID:[{cliente.Id}]Hola soy {cliente.Nombre} tengo {cliente.Edad}Años Y compre ID:[{cliente.Producto2.Codigo}] {cliente.Producto2.Nombre} y me costo:  ${cliente.Producto2.Precio}");
        }
    }
}