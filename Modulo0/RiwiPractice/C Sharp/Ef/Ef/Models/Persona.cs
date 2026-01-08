namespace ef.Models;

public abstract class Persona
{
    public int Id { get; set; } //Siempre ID con ORM
    public string? Nombre { get; set; }
    public int Edad { get; set; }
}