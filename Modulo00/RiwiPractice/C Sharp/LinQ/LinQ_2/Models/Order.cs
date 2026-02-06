namespace LinQ.Models;

public class Order //Orders: OrderId-CustomerId-ProductId-Quantity
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}