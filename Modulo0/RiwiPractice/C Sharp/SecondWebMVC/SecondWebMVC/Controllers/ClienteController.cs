using Microsoft.AspNetCore.Mvc;
using SecondWebMVC.Models;

namespace SecondWebMVC.Controllers;

// Controlador encargado de manejar todas las acciones relacionadas con los Clientes
public class ClienteController : Controller
{
    // Lista estática que almacenará en memoria a todos los clientes creados en la aplicación
    // (NOTA: Al ser estática, los datos se comparten en todas las instancias del controlador mientras dure la ejecución)
    public static readonly List<Cliente> Clientes = [];

    // Acción que retorna la vista principal (Index) mostrando la lista completa de clientes
    public ActionResult Index()
    {
        return View(Clientes);
    }

    // Acción que muestra los detalles de un cliente específico según su Id
    public ActionResult Detalles(int id)
    {
        // Busca el cliente cuyo Id coincida con el parámetro recibido
        var cliente = Clientes.FirstOrDefault(c => c.Id == id);

        // Si no encuentra un cliente con ese Id, retorna un error 404 (NotFound)
        if (cliente == null) return NotFound();

        // Si lo encuentra, envía ese cliente a la vista para mostrar sus detalles
        return View(cliente);
    }

    // Acción que guarda un nuevo cliente en la lista
    public ActionResult Guardar(Cliente cliente)
    {
        /*
         * Lógica para asignar el Id del nuevo cliente:
         * - Si la lista ya tiene clientes: se obtiene el Id más alto con Clientes.Max(c => c.Id) y se le suma 1.
         * - Si la lista está vacía: se asigna el Id = 1.
         */
        cliente.Id = Clientes.Any() ? Clientes.Max(c => c.Id) + 1 : 1;

        // Agrega el cliente recibido a la lista
        Clientes.Add(cliente);

        // Redirige al usuario nuevamente a la lista de clientes (Index)
        return RedirectToAction("Index");
    }

    // Acción que permite editar los datos de un cliente existente
    public ActionResult Editar(Cliente clienteEditado)
    {
        // Busca en la lista el cliente que coincida con el ID del cliente editado
        var cliente = Clientes.FirstOrDefault(c => c.Id == clienteEditado.Id);

        // Si no existe un cliente con ese ID, devuelve un error 404
        if (cliente == null) return NotFound();

        // Si lo encuentra, actualiza cada campo con la nueva información recibida
        cliente.Nombre = clienteEditado.Nombre;
        cliente.Apellido = clienteEditado.Apellido;
        cliente.Sexo = clienteEditado.Sexo;
        cliente.Correo = clienteEditado.Correo;
        cliente.Direccion = clienteEditado.Direccion;
        cliente.Telefono = clienteEditado.Telefono;

        // Después de actualizar, redirige nuevamente a la lista de clientes
        return RedirectToAction("Index");
    }

    // Acción que elimina un cliente de la lista según su Id
    public ActionResult Eliminar(int id)
    {
        // Busca el cliente por Id y lo elimina directamente de la lista
        Clientes.Remove(Clientes.FirstOrDefault(c => c.Id == id)!);

        // Redirige a la lista actualizada de clientes
        return RedirectToAction("Index");
    }
}