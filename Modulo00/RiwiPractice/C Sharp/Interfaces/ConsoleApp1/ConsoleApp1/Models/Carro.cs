using ConsoleApp1.interfaces;

namespace ConsoleApp1.Models;

public class Carro : IElectrico, IGasolina
{
    public void Electrico()
    {
        Console.WriteLine("Carro Electrico");
    }

    public void Gasolina()
    {
        Console.WriteLine("Carro a Gasolina");
    }
}