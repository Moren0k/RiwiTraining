namespace Tienda.Models;
using Interfaces;

public class RepoProducto : ITenda<Producto>
{
    private List<Producto> _productos = new List<Producto>();

    public List<Producto> Productos = [];
    
    public void Agregar(Producto entidad)
    {
        _productos.Add(entidad);
        Productos.Add(entidad);
        Console.WriteLine("Producto agregado");
    }

    public List<Producto> Mostrar()
    {
        return _productos;
    }

    public void Editar(Producto entidad)
    {
        throw new NotImplementedException();
    }

    public void Eliminar(Producto entidad)
    {
        throw new NotImplementedException();
    }
}