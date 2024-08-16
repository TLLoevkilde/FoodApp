using System.ComponentModel.DataAnnotations;

namespace FoodApp.UI.Models.DTO
{
    public class UpdateFoodItemDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double ProteinPerHundredGrams { get; set; }
        [Required]
        public double CalPerHundredGrams { get; set; }
        [Required]
        public double WeightInGrams { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
