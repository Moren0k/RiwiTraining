using Microsoft.AspNetCore.Mvc;
using ShopWeb.Models;
using ShopWeb.Repositories.Interfaces;

namespace ShopWeb.Controllers;

public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userRepository.GetAllAsync();
        var vm = new UserViewModel { Users = users };
        return View(vm);
    }

    public async Task<IActionResult> Details(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return NotFound();
        return View(user);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Users = await _userRepository.GetAllAsync();
            return View("Index", model);
        }

        var user = model.NewUser;
        User? newUser = user.Role switch
        {
            "Admin" => new Admin
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = "Admin"
            },
            "Seller" => new Seller
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = "Seller"
            },
            "Customer" => new Customer
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = "Customer"
            },
            _ => null
        };

        if (newUser == null)
            return BadRequest("Rol inválido");

        await _userRepository.AddAsync(newUser);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return NotFound();
        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(User user)
    {
        if (!ModelState.IsValid)
            return View(user);

        await _userRepository.UpdateAsync(user);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await _userRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
