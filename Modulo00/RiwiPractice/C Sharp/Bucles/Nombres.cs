namespace ConsoleApp1;

public class Nombres
{
    public static void nombres()
    {
        List<string> hombres = new List<string>{};
        List<string> mujeres = new List<string>{};
        
        // Preguntar si quiere ingresar Hombres o Mujeres
        Console.WriteLine("¿Hombres o Mujeres? (H/M)");
        string input = Console.ReadLine().ToLower();

        if (input == "h")
        {
            int contadorH = 0;
            while (true)
            {
                // Ingresar los nombres
                Console.WriteLine("Ingrese el nombre de un Hombre: ");
                string inputH = Console.ReadLine().ToLower();
                hombres.Add(inputH); // Agregar hombre a la lista
                contadorH++; // Contar cuantos hombres se ingresan

                if (inputH == "roberto")
                {
                    foreach (var h in hombres)
                    {
                        Console.WriteLine($"@{h} esta en la lista de hombres!");
                    }
                    Console.WriteLine($"!!!{inputH} Debe plata!!!");
                    Console.WriteLine($"Total de Hombres: {contadorH}");
                    break;
                }
            }
        }
        else if (input == "m")
        {
            int contadorM = 0;
            while (true)
            {
                // Ingresar los nombres
                Console.WriteLine("Ingrese el nombre de una Mujer: ");
                string inputM = Console.ReadLine().ToLower();
                mujeres.Add(inputM); // Agregar mujer a la lista
                contadorM++; // Contar cuantas mujeres se ingresan

                if (inputM == "emilcen")
                {
                    foreach (var m in mujeres)
                    {
                        Console.WriteLine($"@{m} esta en la lista de mujeres!");
                    }
                    Console.WriteLine($"!!!{inputM} Debe plata!!!");
                    Console.WriteLine($"Total de Mujeres: {contadorM}");
                    break;
                }
            }
        }
    }
}