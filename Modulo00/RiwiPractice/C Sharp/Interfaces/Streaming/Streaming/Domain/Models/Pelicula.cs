using System.ComponentModel.DataAnnotations;

namespace Streaming.Domain.Models;

public class Pelicula : Contenido
{
    [Key] public int IdPelicula { get; set; }
    public string? Duracion { get; set; }
}