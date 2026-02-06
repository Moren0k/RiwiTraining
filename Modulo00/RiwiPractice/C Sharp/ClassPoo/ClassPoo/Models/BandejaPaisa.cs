namespace ClassPoo.Models;

public class BandejaPaisa : Almuerzo
{
    public BandejaPaisa(string nombre, string tamaño, double precio) : base(nombre, tamaño, precio)
    {
    }

    public override void Preparar()
    {
        Console.WriteLine("Preparando... Arroz, Carne, Chicharron, Papa, Huevo");
    }

    public override void Servir()
    {
        
    }
}