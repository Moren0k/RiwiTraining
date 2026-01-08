namespace Poo;

// Clase Personaje
public class Personaje
{
    // Propiedades privadas: solo accesibles dentro de esta clase
    private string? Nombre { get; set; }
    private int Fuerza { get; set; }
    private int Inteligencia { get; set; }
    private int Defensa { get; set; }
    private int Vida { get; set; }

    public Personaje(string nombre, int fuerza, int inteligencia, int defensa, int vida) //Constructor
    {
        Nombre = nombre;
        Fuerza = fuerza;
        Inteligencia = inteligencia;
        Defensa = defensa;
        Vida = vida;
    }

    // Método privado: solo puede usarse dentro de la clase
    private void Atacar()
    {
        Console.WriteLine($"Atacando {Nombre} con fuerza {Fuerza} | VIDA {Vida}");
    }

    // Otro método privado, también encapsulado
    private void Moverse()
    {
        Console.WriteLine($"Moviéndose {Nombre} con inteligencia {Inteligencia} | VIDA {Vida}");
    }

    // Método público: sirve como "puerta de acceso" controlada
    // Desde fuera de la clase se puede ejecutar Turno(),
    // pero no directamente Atacar() ni Moverse()
    public void Turno()
    {
        Atacar();
        Moverse();
        Console.WriteLine($"Turno de atacar y moverse con defensa {Defensa}");
    }
}