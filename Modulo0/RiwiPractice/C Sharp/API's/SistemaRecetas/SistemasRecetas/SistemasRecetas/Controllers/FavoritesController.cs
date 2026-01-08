using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemasRecetas;
using SistemasRecetas.Models;

namespace SistemasRecetas.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly AppDbContext _db;

        public FavoritesController(AppDbContext db)
        {
            _db = db;
        }

        // LISTA
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _db.Favorites
                .OrderBy(f => f.Name)
                .ToListAsync();

            return View(list);
        }

        // AGREGAR (desde Recipe/Index)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(string? idMeal, string? name, string? thumb)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                TempData["Msg"] = "Nombre vacío.";
                return RedirectToAction("Index", "Recipe");
            }

            bool exists = !string.IsNullOrWhiteSpace(idMeal)
                && await _db.Favorites.AnyAsync(f => f.IdMeal == idMeal);

            if (!exists)
            {
                var fav = new Favorite
                {
                    IdMeal = idMeal,
                    Name = name?.Trim(),
                    Thumb = thumb
                };

                try
                {
                    _db.Favorites.Add(fav);
                    await _db.SaveChangesAsync();
                    TempData["Msg"] = "Agregado a favoritos.";
                }
                catch (Exception ex)
                {
                    TempData["Msg"] = $"Error BD: {ex.Message}";
                }
            }
            else
            {
                TempData["Msg"] = "Ya estaba en favoritos.";
            }

            return RedirectToAction(nameof(Index));
        }

        // CREAR (manual)
        [HttpGet]
        public IActionResult Create() => View(new Favorite());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Favorite model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                _db.Favorites.Add(model);
                await _db.SaveChangesAsync();
                TempData["Msg"] = "Favorito creado.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Msg"] = $"Error: {ex.Message}";
                return View(model);
            }
        }

        // EDITAR
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var fav = await _db.Favorites.FindAsync(id);
            if (fav == null) return NotFound();
            return View(fav);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Favorite model)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            var fav = await _db.Favorites.FindAsync(id);
            if (fav == null) return NotFound();

            try
            {
                fav.IdMeal = model.IdMeal;
                fav.Name = model.Name;
                fav.Thumb = model.Thumb;
                fav.IngredientsText = model.IngredientsText;
                fav.InstructionsText = model.InstructionsText;

                await _db.SaveChangesAsync();
                TempData["Msg"] = "Favorito actualizado.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Msg"] = $"Error: {ex.Message}";
                return View(model);
            }
        }

        // ELIMINAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var fav = await _db.Favorites.FindAsync(id);
            if (fav == null)
            {
                TempData["Msg"] = "No encontrado.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _db.Favorites.Remove(fav);
                await _db.SaveChangesAsync();
                TempData["Msg"] = "Eliminado.";
            }
            catch (Exception ex)
            {
                TempData["Msg"] = $"Error al eliminar: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
