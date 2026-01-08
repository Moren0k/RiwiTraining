namespace SecondWebMVC.Models;

public class Producto
{
    public int Id { get; set; }
    public string Nombre{ get; set; } = String.Empty;
    public double Precio{ get; set; }
    
    // Relación con Cliente
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
}