using Microsoft.EntityFrameworkCore;
using ShopWeb.Data;
using ShopWeb.Repositories;
using ShopWeb.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString =
    builder.Configuration.GetConnectionString("ConnectionString"); //Traer la cadena de ConnectionString de appsettings

Console.WriteLine($"ConnectionString: {connectionString}");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Aquí se configuran las opciones del AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 29))));

builder.Services.AddScoped<IUserRepository, UserRepository>(); //IUserRepository

var app = builder.Build();

// --- Verificar conexión a la DB ---
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        db.Database.OpenConnection();
        Console.WriteLine("Conexión exitosa a la base de datos.");
        db.Database.CloseConnection();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error de conexión: {ex.Message}");
    }
}
// -----------------------------------

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();