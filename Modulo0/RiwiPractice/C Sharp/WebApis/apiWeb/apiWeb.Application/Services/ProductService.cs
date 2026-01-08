using System.Collections.Generic;
using apiWeb.Domain.Models;

namespace apiWeb.Application.Services;

public class ProductService
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;
    
    //Endpoint (Create, List)

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public Product Add(Product product)
    {
        product.Id = _nextId++;
        _products.Add(product);
        return product;
    }
}