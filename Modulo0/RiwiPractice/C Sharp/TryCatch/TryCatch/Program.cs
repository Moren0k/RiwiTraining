internal class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Ingresa un número: ");
            int num = int.Parse(Console.ReadLine() ?? "0");

            int resultado = 10 / num;
            Console.WriteLine($"Resultado: {resultado}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("No se puede dividir entre cero.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Debes ingresar un número válido.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
        }

//
        Console.Write("Edad: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int edad))
        {
            if (edad >= 18)
                Console.WriteLine("Eres mayor de edad");
            else
                Console.WriteLine("Eres menor de edad");
        }
        else
        {
            Console.WriteLine("Dato no válido");
        }

//
        var lista = new List<int>();

        int zero = 0;
        try
        {
            int x = int.Parse("abc");                 // FormatException
            // ReSharper disable once IntDivisionByZero
            int y = 10 / zero;                           // DivideByZeroException
            var z = lista[5];                      // ArgumentOutOfRangeException
            string? s = null;
            Console.WriteLine(s!.Length);              // NullReferenceException
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Tipo: {ex.GetType().Name}, Mensaje: {ex.Message}");
        }
    }
}
