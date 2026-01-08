using ConsoleApp1.interfaces;

namespace ConsoleApp1.Models;

public class PagoEfectivo : IPago
{
    public void Pagar(string mensaje)
    {
        Console.WriteLine($"Pago con efectivo {mensaje}");
    }
}