using ConsoleApp1.interfaces;

namespace ConsoleApp1.Models;

public class PagoTarjeta : IPago
{
    public void Pagar(string mensaje)
    {
        Console.WriteLine($"Pago con tarjeta {mensaje}");
    }
}