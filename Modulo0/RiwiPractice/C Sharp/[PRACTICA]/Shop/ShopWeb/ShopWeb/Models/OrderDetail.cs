namespace ShopWeb.Models;

public class OrderDetail
{
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double Subtotal { get; set; }
}