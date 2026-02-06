using System.ComponentModel.DataAnnotations;

namespace ShopWeb.Models;

public class Order
{
    [Key] public int Id { get; set; }
    public Customer? Customer { get; set; }
    public DateTime Date { get; set; }
    [Required] public required string Status { get; set; }
    public decimal Total { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}