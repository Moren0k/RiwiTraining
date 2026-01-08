using System.ComponentModel.DataAnnotations;

namespace Streaming.Domain.Models;

public class Episodio : Serie
{
    [Key] public int IdEpisodio { get; set; }
    public string? TituloEpisodio { get; set; }
    public int TemporadaEpisodio { get; set; }
}