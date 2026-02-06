using Customers.Domain.Models;

namespace Customers.Application.Services;

public class CustomersServices
{
    private readonly List<Customer> _customers = new(); //Lista de Customers
    private int _nextId = 1; //Incrementar el ID de los Customers

    /*Crud Infrastructure (NO LOGICA DE NEGOCIO)*/

    //Listar GET
    public IEnumerable<Customer> GetCustomers()
    {
        return _customers;
    }

    //Crear ADD
    public Customer AddCustomer(Customer customer)
    {
        customer.Id = _nextId++;
        _customers.Add(customer);
        return customer;
    }
    
    //Editar UPDATE
    public Customer UpdateCustomer(Customer customer)
    {
        var customerUpdate = _customers.FirstOrDefault(c => c.Id == customer.Id);
        
        //Modificar
        customerUpdate!.Name = customer.Name;
        customerUpdate.LastName = customer.LastName;
        customerUpdate.Email = customer.Email;
        return customerUpdate;
    }
    
    //Eliminar DELETE
    public Customer DeleteCustomer(int id)
    {
        var productDelete = _customers.FirstOrDefault(c => c.Id == id);
        _customers.Remove(productDelete!);
        return productDelete!;
    }
}