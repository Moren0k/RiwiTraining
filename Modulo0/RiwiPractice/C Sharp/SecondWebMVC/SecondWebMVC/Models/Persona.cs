namespace SecondWebMVC.Models;

public abstract class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty; // h.Hombre ° m.Mujer
}