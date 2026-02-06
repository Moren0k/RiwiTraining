using System;

public class Program
{
    static void Main(string[] args)
    {
        
        // Preguntar el nombre
        Console.WriteLine("Cual es tu nombre?");
        string nombre = Console.ReadLine().ToLower();
        
        // Pregunar la edad
        Console.WriteLine("Cual es tu edad?");
        int edad = int.Parse(Console.ReadLine());
        
        //Precio del vuelo
        double precioVuelo = 1_200_000;
        
        // Preguntar en que mes va a viajar
        Console.WriteLine("En que mes vas a viajar?");
        string mes = Console.ReadLine().ToLower();
        
        // Pregunar que dia va a aviajar
        Console.WriteLine("En que dia vas a viajar?");
        string dia = Console.ReadLine().ToLower();
        
        /*LOGICA*/
        double porcentaje = 0;
        
        // Descuento MES
        porcentaje += (mes == "octubre") ? 0.30 :
            (mes == "enero") ? 0.30 :
            (mes == "marzo") ? 0.30 :
            0.0;
        
        // Descuento DIA
        porcentaje += (dia == "lunes") ? 0.10 :
            (dia == "martes") ? 0.10 :
            (dia == "jueves") ? 0.10 :
            0.0;
        
        // Descuento ANDRES
        porcentaje += (nombre == "andres") ? 0.40 : 0.0;
        
        // Calcular el total
        double total = precioVuelo - (precioVuelo * porcentaje);
        
        // MOSTRAR
        Console.WriteLine($"Hola {nombre} tienes {edad} años y el total es: {total}");
    }
}