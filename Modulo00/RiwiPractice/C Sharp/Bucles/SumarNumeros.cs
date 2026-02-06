namespace ConsoleApp1;

public class SumarNumeros
{
    public static void sumas()
    {
        int suma = 0;
        int contador = 0;
        int numero;
        
        while (true)
        {   
            Console.WriteLine("Ingrese un numero: (0 Salir)");
            numero = Convert.ToInt32(Console.ReadLine());
            if (numero == 0)
            {
                break;
            }
            suma += numero;
            contador++;
        }
        Console.WriteLine($"Datos ingresados: {contador}, La suma es {suma}");
    }
}