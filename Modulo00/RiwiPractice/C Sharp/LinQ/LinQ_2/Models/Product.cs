namespace LinQ.Models;

public class Product //Products: ProductId-ProductName-ProductPrice
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public double ProductPrice { get; set; }
}