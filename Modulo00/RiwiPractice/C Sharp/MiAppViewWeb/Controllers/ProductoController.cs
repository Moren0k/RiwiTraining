using MiApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiApp.Controllers;

public class ProductoController : Controller
{
    public IActionResult Index()
    {
        var productos = new List<Producto>
        {
            new Producto{Id=1,Nombre="Milk", Precio = 200.00},
            new Producto{Id=2,Nombre="Cheese",  Precio = 300.00},
            new Producto{Id=3,Nombre="Pepperoni",   Precio = 400.00},
        };
        return View(productos);
    }
}