namespace ShopWeb.Models;

public class ViewModel
{
    public List<Admin> Admins { get; set; } = new();
    public List<Seller> Sellers { get; set; } = new();
    public List<Customer> Customers { get; set; } = new();
}