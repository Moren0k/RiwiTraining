namespace ShopWeb.Models;

public class CreateUser
{
    public class RegisterDto
    {
        public string Role { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}