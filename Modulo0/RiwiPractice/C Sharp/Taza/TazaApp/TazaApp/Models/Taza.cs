using System.Globalization;

namespace TazaApp.Models;

public class Taza
{
    public string? Color { get; set; }
    public string? Tamaño { get; set; }
    public string? Material { get; set; }
    public int Capacidad { get; set; }
    public int CantidadActual { get; set; }

    public Taza(string color, string material, int capacidad, int cantidadActual)
    {
        Color = color;
        Material = material;
        Capacidad = capacidad;
        CantidadActual = 0;
    }
    //Constructor
    public void Llenar(int cantidad)
    {
        if (CantidadActual + cantidad > Capacidad)
        {
            CantidadActual = cantidad;
            Console.WriteLine($"La taza esta llena");
        }
        else
        {
            CantidadActual += cantidad;
            Console.WriteLine($"Se agrego la cantidad {cantidad}");
        }
    }
    
    public void Beber(int cantidad)
    {
        if (cantidad > Capacidad)
        {
            Console.WriteLine($"No hay suficiente liquido para tomar");
        }
        else
        {
            cantidad -= cantidad;
            Console.WriteLine(
                $"La taza {Color}, de {Material}, tiene una capacidad de {Capacidad} y se bebio {cantidad}");
        }
    }
    
    public void Vaciar()
    {
        if (CantidadActual > 0)
        {
            Console.WriteLine("Todavia hay cafe en la taza");
        }
        else
        {
            Console.WriteLine("No hay cafe en la taza");
        }
    }
    
    public virtual void MostrarInfo()
    {
        Console.WriteLine($"El color de la taza {Color} y es de material {Material}.");
    }
}