using System.ComponentModel.DataAnnotations;

namespace SistemasRecetas.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string? IdMeal { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Thumb { get; set; }

        [Display(Name = "Ingredientes (uno por línea)")]
        public string? IngredientsText { get; set; }

        [Display(Name = "Instrucciones")]
        public string? InstructionsText { get; set; }
    }
}