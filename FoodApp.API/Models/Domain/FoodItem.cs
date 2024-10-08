﻿namespace FoodApp.API.Models.Domain
{
    public class FoodItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double ProteinPerHundredGrams { get; set; }
        public double CalPerHundredGrams { get; set; }
        public double WeightInGrams { get; set; }
        public double Price { get; set; }
        public double ProteinPerWeightInGrams { get; set; }
        public int CalPerHundredGramsOfProtein { get; set; }
        public double PricePerHundredGramsOfProtein { get; set; }
        public int Score { get; set; }

    }
}
    