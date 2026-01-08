namespace ClassPoo.Models;
public abstract class Almuerzo
{
    private string? Nombre { get; set; }
    private string? Tamaño { get; set; }
    private double Precio { get; set; }


    protected Almuerzo(string nombre, string tamaño, double precio)
    {
        Nombre = nombre;
        Tamaño = tamaño;
        Precio = precio;
    }
    //Abstract not Using
    public abstract void Preparar();
    public abstract void Servir();
    
    public void MostrarInfo()
    {
        Console.WriteLine($"Almuerzo: {Nombre}, Tamaño: {Tamaño}, Precio: {Precio}");
    }
}