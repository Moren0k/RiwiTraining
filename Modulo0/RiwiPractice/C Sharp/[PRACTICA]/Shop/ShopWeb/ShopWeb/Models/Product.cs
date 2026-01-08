using System.ComponentModel.DataAnnotations;

namespace ShopWeb.Models;

public abstract class Product
{
    [Key] public int Id { get; set; }
    [Required] public required string Name { get; set; }
    public string Description { get; set; } = String.Empty;
    public string ImageUrl { get; set; } = String.Empty;
    public double Price { get; set; }
    public int Stock { get; set; }
}