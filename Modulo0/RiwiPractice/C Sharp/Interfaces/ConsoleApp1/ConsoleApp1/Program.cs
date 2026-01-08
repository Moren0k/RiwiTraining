using ConsoleApp1.interfaces;
using ConsoleApp1.Models;

namespace ConsoleApp1;

public static class Program
{
    public static void Main(string[] args)
    {
        // Ejemplo 1
        var mot = new Moto();
        mot.Electrico();
        mot.Gasolina();
        var car = new Carro();
        car.Electrico();
        car.Gasolina();

        Console.WriteLine();
        //Ejemplo 2
        var pagos = new List<IPago>
        {
            new PagoEfectivo(),
            new PagoTarjeta(),
        };

        foreach (var pago in pagos)
        {
            pago.Pagar("PAGO REALIZADO");
        }
    }
}