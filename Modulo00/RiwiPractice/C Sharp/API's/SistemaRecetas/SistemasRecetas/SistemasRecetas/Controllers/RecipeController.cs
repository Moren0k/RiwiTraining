using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemasRecetas;
using SistemasRecetas.Models;
using System.Text.Json;

namespace SistemasRecetas.Controllers
{
    public class RecipeController : Controller
    {
        private readonly AppDbContext _db;

        public RecipeController(AppDbContext db)
        {
            _db = db;
        }

        // GET /Recipe/Index?name=pizza, pasta
        [HttpGet]
        public async Task<IActionResult> Index(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return View(new List<Recipe>());

            // Separar por coma y limpiar
            var queries = name
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(q => q.Trim())
                .Where(q => q.Length > 0)
                .ToList();

            // Llamadas en paralelo a la API
            var tasks = queries.Select(q => GetRecipesAsync(q)).ToList();
            var results = await Task.WhenAll(tasks);

            // Unir resultados
            var allMeals = results
                .Where(r => r?.Meals != null)
                .SelectMany(r => r!.Meals!)
                .ToList();

            //  Traer los IdMeal que ya están en favoritos para desactivar el botón
            var favIds = await _db.Favorites
                .Select(f => f.IdMeal!)
                .Where(id => id != null)
                .ToListAsync();

            ViewBag.FavIds = favIds; // la vista usará esto para mostrar "Ya agregada"

            return View(allMeals);
        }

        // Llamada a TheMealDB (básica y robusta)
        public static async Task<RecipeResponse?> GetRecipesAsync(string name)
        {
            try
            {
                using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
                var api = $"https://www.themealdb.com/api/json/v1/1/search.php?s={Uri.EscapeDataString(name)}";

                var response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                return JsonSerializer.Deserialize<RecipeResponse>(json, options);
            }
            catch
            {
                // Si falla, devolvemos una respuesta vacía para no romper la vista
                return new RecipeResponse { Meals = new List<Recipe>() };
            }
        }
    }
}
