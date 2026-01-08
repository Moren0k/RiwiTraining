using ConsoleApp1.interfaces;

namespace ConsoleApp1.Models;

public class Moto : IElectrico, IGasolina
{
    public void Electrico()
    {
        Console.WriteLine("Moto Electrica");
    }

    public void Gasolina()
    {
        Console.WriteLine("Moto Gasolina");
    }
}