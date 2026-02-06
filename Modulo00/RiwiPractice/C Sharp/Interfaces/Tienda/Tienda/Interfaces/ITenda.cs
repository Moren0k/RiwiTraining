using Tienda.Models;

namespace Tienda.Interfaces;

public interface ITenda<T> where T : class
{
    void Agregar(T entidad);
    List<Producto> Mostrar();
    void Editar(T entidad);
    void Eliminar(T entidad);
}