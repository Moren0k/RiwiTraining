using System.ComponentModel.DataAnnotations;

namespace ShopWeb.Models;

public class Cart
{
    [Key] public int Id { get; set; }
    public Customer? Customer { get; set; }
    public List<ItemCart> Items { get; set; } = new List<ItemCart>();
}