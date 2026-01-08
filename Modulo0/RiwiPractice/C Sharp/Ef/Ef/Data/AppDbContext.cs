using ef.Models;
using Microsoft.EntityFrameworkCore;

namespace ef.Data;

public class AppDbContext : DbContext
{
    public DbSet<Profesor> Profesores { get; set; }
    public DbSet<Estudiante> Estudiantes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
                "server=localhost;database=riwi;user=root;password=",
                new MySqlServerVersion(new Version(8, 0, 36))
            );
        }
    }
}