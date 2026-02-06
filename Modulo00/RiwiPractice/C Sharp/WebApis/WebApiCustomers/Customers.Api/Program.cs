using Customers.Application.Services;
using Customers.Domain.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//Inject dependency
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<CustomersServices>();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// 2️⃣ Middleware
app.UseCors("AllowAll");
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Exponer los EndPoints

/*PRODUCT*/
app.MapGet("/getProduct", (ProductService productService) => //GET
{
    return Results.Ok(productService.GetProducts());
});

app.MapPost("/addProduct", (Product product, ProductService productService) => //POST
{
    var newProduct = productService.AddProduct(product);
    return Results.Created($"api/product/{product.Id}", newProduct);
});

app.MapPatch("/updateProduct/{id}", (Product product, ProductService productService) => //PATCH
{
    return productService.UpdateProduct(product);
});

app.MapDelete("/deleteProduct/{id}", (int id, ProductService productService) => //DELETE
{
    return productService.DeleteProduct(id);
});

/*CUSTOMERS*/
app.MapGet("/getCustomer", ([FromServices] CustomersServices customersServices) =>
{
    return Results.Ok(customersServices.GetCustomers());
});

app.MapPost("/addCustomer", ([FromBody] Customer customer, [FromServices] CustomersServices customersServices) =>
{
    var newCustomer = customersServices.AddCustomer(customer);
    return Results.Created($"api/customer/{customer.Id}", newCustomer);
});

app.MapPatch("/updateCustomer/{id}", ([FromBody] Customer customer, [FromServices] CustomersServices customersServices) =>
{
    return customersServices.UpdateCustomer(customer);
});

app.MapDelete("/deleteCustomer/{id}", (int id, [FromServices] CustomersServices customersServices) =>
{
    return customersServices.DeleteCustomer(id);
});


app.Run();
