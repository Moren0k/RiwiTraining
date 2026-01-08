using Microsoft.EntityFrameworkCore;
using Streaming.Domain.Models;

namespace Streaming.Data;

public class AppDbContext : DbContext
{
    public DbSet<Pelicula> Peliculas { get; set; }
    public DbSet<Serie> Series { get; set; }
    public DbSet<Episodio> Episodios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;database=riwiflix;user=admin;password=";
        optionsBuilder.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        );
    }
}