using Microsoft.AspNetCore.Identity;
using ProjectCore.Infrastructure.Auth;

namespace ProjectCore.Infrastructure.Seed;

public static class UserSeeder
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
    {
        const string email = "admin@projectcore.com";
        const string password = "Admin123!";

        var user = await userManager.FindByEmailAsync(email);

        if (user != null)
            return;

        var newUser = new ApplicationUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };
        await userManager.CreateAsync(newUser, password);
    }
}