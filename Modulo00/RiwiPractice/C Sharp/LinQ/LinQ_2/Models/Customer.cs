namespace LinQ.Models;

public class Customer //Customer: CustomerId-CustomerName-CustomerEmail
{
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
}