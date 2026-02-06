namespace ClassPoo.Models;

public class Hamburgesa : Almuerzo
{
    public Hamburgesa(string nombre, string tamaño, double precio) : base(nombre, tamaño, precio)
    {
    }

    public override void Preparar()
    {
        Console.WriteLine("Preparando... Pan, Carne, Ensalada, Papa, Gaseosa");
    }

    public override void Servir()
    {
        
    }
}