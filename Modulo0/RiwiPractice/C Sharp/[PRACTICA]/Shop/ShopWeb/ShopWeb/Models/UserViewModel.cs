namespace ShopWeb.Models;

public class UserViewModel
{
    public IEnumerable<User> Users { get; set; } = new List<User>();
    public User NewUser { get; set; } = new()
    {
        FirstName = null,
        LastName = null,
        Email = null,
        Password = null,
        Role = null
    };
}