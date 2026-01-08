using System.Text.Json;

namespace Universidades_Api;

public static class Program
{
    static async Task Main()
    {
        await test1();
    }

    public class Univer()
    {
        public string pais { get; set; }
        public string name { get; set; }
        public List<string> web_pages { get; set; }
    }

    static async Task test1()
    {
        bool op = true;
        do
        {
            try
            {
                Console.WriteLine("indique un país");
                String pais = Console.ReadLine();

                string api = $"http://universities.hipolabs.com/search?country={pais}";
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(api);
                List<Univer> universi = JsonSerializer.Deserialize<List<Univer>>(response);


                foreach (Univer u in universi.Take(9))
                {
                    Console.WriteLine($"{u.name} ");
                    foreach (var z in u.web_pages)
                    {
                        Console.WriteLine($"WebPage: {z}");
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("Desea buscar universidades de otro país     YES/NO");
                String p = Console.ReadLine().ToLower();

                if (p == "no")
                {
                    op = false;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error al conectar: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error inesperado: {e.Message}");
            }
        } while (op == true);
    }
}