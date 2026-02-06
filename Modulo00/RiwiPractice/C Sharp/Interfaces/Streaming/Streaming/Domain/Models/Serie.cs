using System.ComponentModel.DataAnnotations;

namespace Streaming.Domain.Models;

public class Serie : Contenido
{
    [Key] public int IdSerie { get; set; }
    public int Temporadas { get; set; }
    public List<Episodio> Episodios { get; set; }
}