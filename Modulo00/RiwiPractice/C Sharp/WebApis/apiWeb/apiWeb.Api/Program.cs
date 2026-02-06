using apiWeb.Application.Services;
using apiWeb.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

//Inject dependencies
builder.Services.AddSingleton<ProductService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Exponer los EndPoints
app.MapGet("getProductos", (ProductService service) =>
{
    return Results.Ok(service.GetAll());
});

app.MapPost("addProductos", (Product product, ProductService service) =>
{
    var create = service.Add(product);
    return Results.Created($"api/product/{product.Id}", create);
});

app.Run();
