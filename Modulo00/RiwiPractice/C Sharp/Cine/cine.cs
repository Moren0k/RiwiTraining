using System;

public class Program
{
    static void Main(string[] args)
    {
        // Definir el valor de la entrada
        double boleta = 1000;
        // Definir el total
        double TOTAL = 0;
        
        /* Pedir datos */
            // Pedir el nombre
            Console.WriteLine("Cual es tu nombre!");
            string nombre = Console.ReadLine();
            
            // Pedir la edad
            Console.WriteLine("Cual es tu edad?");
            int edad =  int.Parse(Console.ReadLine());
            
            // Pedir el dia 
            Console.WriteLine("Que dia es hoy?");
            string dia = Console.ReadLine().ToLower();
            
            // Preguntar si tiene tarjeta Ds
            Console.WriteLine("Tiene tarjeta de descuento? (True/False)");
            bool tiene = bool.Parse(Console.ReadLine());
        
        // Logica descuento dia miercoles
        if (dia == "miercoles")
        {
            double descuentoM = boleta * 0.25;
            TOTAL = boleta - descuentoM;
            Console.WriteLine($"Tu descuento por ser miercoles es: {descuentoM} y quedo en: {TOTAL}");
        }
        else
        {
            TOTAL = TOTAL + boleta;
            Console.WriteLine($"Hoy no hay descuento tu boleta cuesta: {boleta}");
        }
        
        // Logica descuento adicional por tener tarjeta
        if (tiene == true)
        {
            double descuentoTiene = TOTAL * 0.25;
            TOTAL = TOTAL - descuentoTiene;
            Console.WriteLine($"Como tienes tj tu descuento adicional es de : {descuentoTiene}");
            Console.WriteLine($"Y tu boleta queda en {TOTAL}");
        }
        else
        {
            Console.WriteLine("Como no tienes tarjeta no tiene mas descuentos!");
        }
        
        // Logica para descuento por edades
        double descuentoE = edad <= 5 ? TOTAL - (TOTAL * 0.25) :
            edad <= 18 ? TOTAL - (TOTAL * 0.15) :
            0;
        TOTAL -= descuentoE;
        if (descuentoE == 0)
        {
            Console.WriteLine("No tienes descuentos por la edad!");
        }
        else
        {
            Console.WriteLine($"El descuento por edad fue de : {descuentoE}");
        }

        // Resumen
        Console.WriteLine("=== RESUMEN ===");
        Console.WriteLine($"@ {nombre} Este es el total final >>> TOTAL A PAGAR= $ {TOTAL}");
    }
}