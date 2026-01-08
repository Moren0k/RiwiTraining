using Microsoft.EntityFrameworkCore;
using ShopWeb.Models;

namespace ShopWeb.Data;

public class AppDbContext : DbContext // Esta clase representa la conexión y comunicación con la base de datos
{
    //Construcción de las tablas en la DB con EF
    public DbSet<User> Users { get; set; } //Actores
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Una sola tabla para todos los tipos derivados
        modelBuilder.Entity<User>()
            .ToTable("Users")
            .HasDiscriminator<string>("Role")
            .HasValue<Admin>("Admin")
            .HasValue<Seller>("Seller")
            .HasValue<Customer>("Customer");
    }
    
    // Constructor del contexto
    // Recibe las opciones de configuración (la cadena de conexión)
    // y se las pasa al constructor de la clase base (DbContext)
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}