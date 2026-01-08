using System.ComponentModel.DataAnnotations;

namespace ShopWeb.Models;

public class User
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(50)] public required string FirstName { get; set; } = "";
    [Required] [MaxLength(50)] public required string LastName { get; set; } = "";
    [Required] [MaxLength(100)] public required string Email { get; set; } = "";
    [Required] [MaxLength(100)] public required string Password { get; set; } = "";
    [Required] [MaxLength(20)] public required string Role { get; set; } = ""; // Discriminator manual o automático
}