using firstMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstMvc.Controllers;

public class ProductoController :Controller
{


    private static List<Producto> _productos = new List<Producto>
    {
        new Producto { ID = 1, Nombre = "Cuchara", Descripcion = "Es redonda" },
        new Producto { ID = 2, Precio = 800, Nombre = "Labios rojos" }
    };
    private int contador = _productos.Count;
    public IActionResult Index()
    {
        return View(_productos);
    }

    public IActionResult Details(int id)
    {
        var produc = _productos;
        
        var pro = produc.FirstOrDefault(produc=>produc.ID == id);
        if (pro == null) return NotFound();
        return View(pro);
    }

    public IActionResult Store(Producto producto)
    {
        contador++;
        producto.ID = contador;
        _productos.Add(producto);
        return RedirectToAction("Index");
    }
}
