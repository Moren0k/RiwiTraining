namespace ExampleLinq;

public class Program
{
    public class Coder // Representa un programador
    {
        public int Id { get; init; } //Nunca cambia → init;
        public string? Name { get; set; }
        public int Age { get; set; }
        public Language? Language { get; set; } // Usamos set; porque esta propiedad sí puede cambiar después de crear el objeto.
    }

    public class Language //Representa los lenguajes
    {
        public int Id { get; init; }
        public string? Name { get; set; }
    }
    
    /*MAS SIMPLE*/
    public record Tls(int Id, string Name, int Age, LanguageTls LanguageTls);//Representa un TL
    public record LanguageTls(int Id, string Name);//Representa el lenguaje de un Tls

    public static void Main()
    {
        //Crear categorias
        var language1 = new Language { Id = 1, Name = "C#" };
        var language2 = new Language { Id = 2, Name = "Java" };

        //Crear Coders
        var coder1 = new Coder { Id = 1, Name = "Kevin", Age = 21, Language = language1 };
        var coder2 = new Coder { Id = 2, Name = "Camila", Age = 20, Language = language2 };

        //Guardarlos en una colleción(lista)
        List<Coder> coders = new List<Coder> { coder1, coder2 };
        foreach (var coder in coders)
        {
            Console.WriteLine(
                $"{coder.Id} - Hola soy {coder.Name}, tengo {coder.Age} years old, y programo con {coder.Language?.Name} {coder.Language?.Id}");
        }

        /*MAS SIMPLE*/
        //Crear Categorias Tls
        var LanguageTl1 = new LanguageTls(1, "C# Senior");
        var LanguageTl2 = new LanguageTls(2, "Java Senior");
        
        //Crear Tls
        var tl1 = new Tls(1, "Andres", 29, LanguageTl1);
        var tl2 = new Tls(2, "David", 29, LanguageTl2);
        var TlsList = new List<Tls> { tl1, tl2 };
        foreach (var tl in TlsList)
        {
            Console.WriteLine($"Hola soy {tl.Name} tengo {tl.Age}Años y enseño {tl.LanguageTls?.Name} {tl.LanguageTls?.Id}");
        }
    }
}