using System.ComponentModel.DataAnnotations;

namespace ShopWeb.Models;

public class Customer : User
{
    [Required] [MaxLength(100)] public required string Address { get; set; }
    [Required] [MaxLength(50)] public required string Phone { get; set; }
}