namespace Poo;

public class Herencia
{
    // Guerrero hereda de Personaje
    public class Guerrero : Personaje
    {
        public int Espada { get; set; }
        public string? Armadura { get; set; }

        public Guerrero(string nombre, int fuerza, int inteligencia, int defensa, int vida, int espada,
            string? armadura)
            : base(nombre, fuerza, inteligencia, defensa, vida) //Constructor
        {
            Espada = espada;
            Armadura = armadura;
        }

        public void Habilidad()
        {
            Console.WriteLine($"Habilidad");
            Console.WriteLine($"Espada: {Espada}");
            Console.WriteLine($"Armadura: {Armadura}");
        }
    }

    // Mago hereda de Personaje
    public class Mago
    {
        public int Magia { get; set; }
        public string? NombreLibro { get; set; }

        public Mago(int magia, string nombreLibro)
        {
            Magia = magia;
            NombreLibro = nombreLibro;
        }

        public void Libro()
        {
            Console.WriteLine($"Libro {NombreLibro}");
        }
    }
}