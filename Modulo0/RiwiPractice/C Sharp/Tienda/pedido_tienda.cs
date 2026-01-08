using System;

namespace tienda
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pedir el nombre del cliente.
            Console.WriteLine("Nombre del cliente?");
            string nombre = Console.ReadLine();
            
            // Preguntar cuantas manzanas queire comprar.
            Console.WriteLine("Cuantas manzanas quieres comprar?");
            int manzanas = int.Parse(Console.ReadLine());
            
            // Pregunar el precio de las manzanas.
            Console.WriteLine("Precio por manzana?");
            double precioManzana = double.Parse(Console.ReadLine());
            
            // Calcular el costo total de las manzanas
            var totalManzanas = manzanas * precioManzana;
            
            // Preguntar si quiere un volsa
            Console.WriteLine("Desea una bolsa?");
            var bolsa = bool.Parse(Console.ReadLine());
            int precioBolsa = 200; // Precio de la bolsa

            double Total = 0;
            
            // Sumar le precio de la bolsa al total
            if (bolsa)
            {
                Total = totalManzanas + precioBolsa;
            }
            else
            {
                Total = totalManzanas;
            }
            
            // Mostrar un resumen de la compra
            Console.WriteLine($"Nombre del cliente: {nombre}");
            Console.WriteLine($"Cantidad de manzanas y su costo: {precioManzana}");
            
            // Mostrar precio de la bolsa si la pidio
            if (bolsa)
            {
                Console.WriteLine($"El precio de la bolsa es: {precioBolsa}");
            }
            Console.WriteLine($"El total de la compra es: {Total}");
            
        }
    }
}