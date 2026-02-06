namespace Poo;

// Clase Cancion: representa el concepto de canción en una biblioteca de música
// Abstracción: se modelan solo los atributos y comportamientos necesarios para este contexto
public class Cancion // Cancion para una Biblioteca de Música
{
    public string? Nombre { get; set; }
    public string? Artista { get; set; }
    public int Duracion { get; set; }
    public string? Genero { get; set; }
    
    public Cancion(string nombre, string artista, int duracion, string genero) //Constructor
    {
        Nombre = nombre;
        Artista = artista;
        Duracion = duracion;
        Genero = genero;
    }

    // Método que abstrae la acción de "escuchar una canción"
    public void Escuchar()
    {
        Console.WriteLine($"Reproduciendo: {Nombre} de {Artista}, Género: {Genero} y Duración: {Duracion}");
    }
}

// Clase CancionVenta: representa el concepto de canción en un sistema de ventas
// Abstracción: se eligen atributos y métodos distintos, adecuados para este otro contexto
public class CancionVenta // Cancion para una Página de Ventas
{
    private string? Nombre { get; set; }
    private string? Artista { get; set; }
    private double Precio { get; set; }

    public CancionVenta(string nombre, string artista, double precio) //Constructor
    {
        Nombre = nombre;
        Artista = artista;
        Precio = precio;
    }

    // Método que abstrae la acción de "poner en venta una canción"
    public void Vender()
    {
        Console.WriteLine($"En venta: {Nombre} de {Artista}, Precio: {Precio}");
    }
}