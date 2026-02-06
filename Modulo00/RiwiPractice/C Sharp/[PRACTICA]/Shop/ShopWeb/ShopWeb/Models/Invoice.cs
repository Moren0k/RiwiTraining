using System.ComponentModel.DataAnnotations;

namespace ShopWeb.Models;

public class Invoice
{
    [Key] public int Id { get; set; }
    public Order? Order { get; set; }
    public DateTime IssueDate { get; set; }
    public double TotalAmount { get; set; }
    [Required] public required string PaymentMethod { get; set; }
    [Required] public required string Status { get; set; }
}