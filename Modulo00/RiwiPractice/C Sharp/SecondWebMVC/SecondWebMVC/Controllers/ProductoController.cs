using Microsoft.AspNetCore.Mvc;
using SecondWebMVC.Models;

namespace SecondWebMVC.Controllers;

public class ProductoController : Controller
{
    private static readonly List<Producto> Productos = []; //Lista que guarda los Productos
    private static readonly List<Cliente> Clientes = ClienteController.Clientes; // reutilizar clientes

    public ActionResult Index() //Muestra los Productos
    {
        return View(Productos);
    }
    
    public ActionResult CrearProducto(Producto producto) //Crear un nuevo Producto
    {
        producto.Id = Productos.Any() ? Productos.Max(p => p.Id) +1 : 1;
        
        // Asociar al cliente
        var cliente = Clientes.FirstOrDefault(c => c.Id == producto.ClienteId);
        if (cliente == null) return NotFound();
        
        producto.Cliente = cliente;
        
        Productos.Add(producto);
        return RedirectToAction("Index");
    }

    public ActionResult EditarProducto(Producto productoEditado) //Editar un Producto.ID
    {
        var producto = Productos.FirstOrDefault(p => p.Id == productoEditado.Id);
        if (producto == null) return NotFound();
        
        producto.Id = productoEditado.Id;
        producto.Nombre = productoEditado.Nombre;
        producto.Precio = productoEditado.Precio;
        return RedirectToAction("Index");
    }

    public ActionResult EliminarProducto(int id) //Eliminar un Producto.ID
    {
        Productos.Remove(Productos.FirstOrDefault(p => p.Id == id)!);
        return RedirectToAction("Index");
    }
}