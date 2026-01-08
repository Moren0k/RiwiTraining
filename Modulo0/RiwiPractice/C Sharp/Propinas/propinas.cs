using System;

public class Program
{
    static void Main(string[] args)
    {   
        // Pedir el valor de la cuenta
        Console.WriteLine("Ingresa el valor total de la cuenta:");
        double cuenta = double.Parse(Console.ReadLine());

        bool i = true;
        
        while (i)
        {
            // Pregunar el nivel de satifaccion
            Console.WriteLine("Cual fue el nivel del servicio?");
            Console.WriteLine("1= malo, 2= regular, 3= bueno, 4= excelente");
            int nivel = int.Parse(Console.ReadLine());

            if (nivel >= 1 && nivel <= 4)
            {
                // Logica para calcular la propina
                double propina = nivel == 1 ? cuenta * 0.5 :
                    nivel == 2 ? cuenta * 0.10 :
                    nivel == 3 ? cuenta * 0.15 :
                    nivel == 4 ? cuenta * 0.20 :
                    0;
                // Mostrar el total a pagar con la propina incluida
                double TOTAL = cuenta + propina;
                Console.WriteLine($"El total de la cuenta es: {cuenta}, La propina es: {propina}, y el total fue: {TOTAL}");
                i = false;
            }
            else
            {
                Console.WriteLine("Ingresa un nivel del servicio valido");
                continue;
            }
        }
    }
}