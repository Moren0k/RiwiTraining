using System.ComponentModel.DataAnnotations;

namespace SistemasRecetas.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string? strMeal { get; set; }

        public string? strInstructions { get; set; }

        [MaxLength(500)]
        public string? strMealThumb { get; set; }

        // Ingredientes según TheMealDB (sin medidas)
        public string? strIngredient1  { get; set; }
        public string? strIngredient2  { get; set; }
        public string? strIngredient3  { get; set; }
        public string? strIngredient4  { get; set; }
        public string? strIngredient5  { get; set; }
        public string? strIngredient6  { get; set; }
        public string? strIngredient7  { get; set; }
        public string? strIngredient8  { get; set; }
        public string? strIngredient9  { get; set; }
        public string? strIngredient10 { get; set; }
        public string? strIngredient11 { get; set; }
        public string? strIngredient12 { get; set; }
        public string? strIngredient13 { get; set; }
        public string? strIngredient14 { get; set; }
        public string? strIngredient15 { get; set; }
        public string? strIngredient16 { get; set; }
        public string? strIngredient17 { get; set; }
        public string? strIngredient18 { get; set; }
        public string? strIngredient19 { get; set; }
        public string? strIngredient20 { get; set; }
        
        public string? idMeal { get; set; } 

        
        // Método simple que devuelve los ingredientes no vacíos
        public IEnumerable<string> GetIngredientsLines()
        {
            for (int i = 1; i <= 20; i++)
            {
                var ing = GetType().GetProperty($"strIngredient{i}")?.GetValue(this) as string;
                if (!string.IsNullOrWhiteSpace(ing))
                    yield return ing!.Trim();
            }
        }
    }
}