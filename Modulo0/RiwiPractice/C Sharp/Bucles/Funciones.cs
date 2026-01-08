public class Funciones
{
    public static void example()
    {
        int suma = Suma(5,5);
        Console.WriteLine($"La suma es {suma}");
        
        int multiplicacion = Multiplicacion(5, 5);
        Console.WriteLine($"La multiplicacion es {multiplicacion}");
    }

    public static int Suma(int a, int b)
    {
        return a + b;
    }

    public static int Multiplicacion(int a, int b)
    {
        return a * b;
    }
}