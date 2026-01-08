namespace Streaming.Domain.Models;

public abstract class Contenido
{
    public int IdContenido { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public int Clasificacion { get; set; }
}