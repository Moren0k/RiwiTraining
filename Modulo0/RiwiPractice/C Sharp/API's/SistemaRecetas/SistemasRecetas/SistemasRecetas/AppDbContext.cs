using Microsoft.EntityFrameworkCore;
using SistemasRecetas.Models;

namespace SistemasRecetas;

public class AppDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    
    public DbSet<Favorite> Favorites { get; set; } = null!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}