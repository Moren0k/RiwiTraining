using Customers.Domain.Models;

namespace Customers.Application.Services;

public class ProductService
{
    private readonly List<Product> _products = new(); //Lista de Products
    private int _nextId = 1; //Incrementar el ID de los Products
    
    /*Crud Infrastructure (NO LOGICA DE NEGOCIO)*/
    
    //Listar GET
    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
    
    //Crear ADD
    public Product AddProduct(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
        return product;
    }
    
    //Editar UPDATE
    public Product UpdateProduct(Product product)
    {
        var productUpdate = _products.FirstOrDefault(p => p.Id == product.Id ); //BUSCARLO
        
        //Modificarlo
        productUpdate!.Name = product.Name;
        productUpdate.Description = product.Description;
        productUpdate.Price = product.Price;
        return productUpdate;
    }
    
    //Eliminar DELETE
    public Product DeleteProduct(int id)
    {
        var productDelete = _products.FirstOrDefault(p => p.Id == id);
        _products.Remove(productDelete!);
        return productDelete!;
    }
}