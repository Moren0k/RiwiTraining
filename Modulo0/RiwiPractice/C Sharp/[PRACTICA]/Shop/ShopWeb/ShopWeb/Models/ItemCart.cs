namespace ShopWeb.Models;

public abstract class ItemCart
{
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}