namespace Persona.Models;

public class Persona
{
    public string Nombre { get; set; }

    public Persona(string nombre)
    {
        this.Nombre = nombre;
    }
}