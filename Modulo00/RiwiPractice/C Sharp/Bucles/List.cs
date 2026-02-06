using System.Collections;

namespace ConsoleApp1;

public class List
{
    public static void exampleList()
    {
        List<string> frutas = new List <string> {"banano", "peras", "papaya", "mango"};
        frutas.Remove("banano");
        frutas.Add("manzana");
        
        List<int> edades = new List<int> { 10, 20, 30, 40, 50 };

        foreach (string fruta in frutas)
        {
            Console.WriteLine(fruta);
        }

        foreach (int edad in edades)
        {
            Console.WriteLine(edad);
        }

        ArrayList name = new ArrayList();
        name.Add(1000);
        name.Add("Hola Mundo");
        name.Add(5.2);
        name.Add(true);

        foreach (var dato in name)
        {
            Console.WriteLine(dato);
        }
    }
}