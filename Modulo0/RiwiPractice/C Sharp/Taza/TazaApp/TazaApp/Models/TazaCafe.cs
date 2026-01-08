namespace TazaApp.Models;

public class TazaCafe : Taza
{
    public string? TipoCafe { get; set; }
    public bool TieneEspuma { get; set; }
    
    public TazaCafe(string color, string material, int capacidad, int cantidadActual) : base(color, material, capacidad, cantidadActual)
    {
        
    }
}