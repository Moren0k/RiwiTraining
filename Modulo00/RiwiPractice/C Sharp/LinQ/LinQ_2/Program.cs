using LinQ.Models;
/*  Products: ProductId ProductName ProductPrice
    Customer: CustomerId CustomerName CustomerEmail
    Orders: OrderId CustomerId ProductId Quantity */
namespace LinQ;

public static class Program
{
    static void Main()
    {
        // Create collection of Products
        var products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Shampoo", ProductPrice = 500 },
            new Product { ProductId = 2, ProductName = "Agua", ProductPrice = 2000 },
            new Product { ProductId = 3, ProductName = "Cepillo", ProductPrice = 2500 },
        };

        // Create collection of Customers
        var customers = new List<Customer>
        {
            new Customer{CustomerId = 1, CustomerName = "David", CustomerEmail = "andres@gmail.com"},
            new Customer{CustomerId = 2, CustomerName = "Luisa", CustomerEmail = "Luisa@gmail.com"},
            new Customer{CustomerId = 3, CustomerName = "Kevin", CustomerEmail = "kevin@gmail.com"}
        };

        // Create collection of Orders
        var orders = new List<Order>
        {
            new Order { OrderId = 1, CustomerId = 1, ProductId = 2, Quantity = 3 },
            new Order { OrderId = 2, CustomerId = 2, ProductId = 3, Quantity = 4 },
            new Order { OrderId = 3, CustomerId = 3, ProductId = 1, Quantity = 2 },
        };

        //LINQ
        // Products with priced less than 1000
        var queryP = from p in products where p.ProductPrice < 1000 select p;
        foreach (var p in queryP)
        {
            Console.WriteLine($"{p.ProductName} MySQL <1000");
        }
        var queryPLambda = products.Where(p => p.ProductPrice < 1000);
        foreach (var p in queryPLambda)
        {
            Console.WriteLine($"{p.ProductName} Lambda <1000");
        }

        // Products with priced greater than 1500
        var queryP2 = from p in products where p.ProductPrice > 1500 select p;
        foreach (var p in queryP2)
        {
            Console.WriteLine($"{p.ProductName} MySQL <1500");
        }
        var queryPLambda2 = products.Where(p => p.ProductPrice > 1500);
        foreach (var p in queryPLambda2)
        {
            Console.WriteLine($"{p.ProductName} Lambda <1500");
        }

        // Show all Customers
        var queryC = from c in customers select c;
        foreach (var c in queryC)
        {
            Console.WriteLine($"{c.CustomerName} MySQL");
        }
        var queryCLambda = customers.Select(c => c.CustomerName);
        foreach (var c in queryCLambda)
        {
            Console.WriteLine($"{c} Lambda");
        }

        // Order Products by priced
        var queryOp = from p in products.OrderByDescending(p => p.ProductPrice) select p;
        foreach (var p in queryOp)
        {
            Console.WriteLine($"{p.ProductPrice}");
        }
        var queryOpLambda = products.OrderByDescending(p => p.ProductPrice);
        foreach (var p in queryOpLambda)
        {
            Console.WriteLine($"{p.ProductPrice} OrderBy Lambda");
        }

        // Verify if all Products cost more for 400
        bool queryVprice = products.All(p => p.ProductPrice > 400);
        Console.WriteLine($"Los productos son mayores de 400? [{queryVprice}]");
        // Verify if all Customers have Email
        bool queryVemail = customers.All(c => c.CustomerEmail != "");
        Console.WriteLine($"Todos los clientes tienen Email? [{queryVemail}]");

        // Verify if a Product with id "2" exist
        var queryVidP = products.Select(p => p.ProductId);
        bool existeIdP = queryVidP.Contains(2);
        Console.WriteLine($"El producto[2] existe? {existeIdP}");

        // Verify if a Customer with id "2" exist
        var queryVidC = customers.Select(c => c.CustomerId);
        bool existeIdC = queryVidC.Contains(1);
        Console.WriteLine($"El cliente [1] existe? {existeIdC}");

        // Verify if a Customer with Name "Kevin" exist
        var queryVnameC = customers.Select(c => c.CustomerName);
        bool existeNameC = queryVnameC.Contains("Kevin");
        Console.WriteLine($"El cliente [Kevin] existe? {existeNameC}");

        // Show Orders whit Name of Customer and Product with Price
        var queryMorders = from o in orders
            join c in customers on o.CustomerId equals c.CustomerId
            join p in products on o.ProductId equals p.ProductId
            select new
            {
                o.OrderId,
                c.CustomerName,
                p.ProductName,
                o.Quantity,
                Total = o.Quantity * p.ProductPrice
            };
        foreach (var od in queryMorders)
        {
            Console.WriteLine($"{od.CustomerName} compró {od.Quantity}x {od.ProductName} = {od.Total}");
        }
    }
}