namespace SecondWebMVC.Models;

public class Cliente : Persona
{
    public string Correo { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Telefono { get; set; }  = string.Empty;
}