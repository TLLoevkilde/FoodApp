﻿using System.ComponentModel.DataAnnotations;

namespace FoodApp.API.Models.DTO
{
    public class CreateFoodItemDto
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
