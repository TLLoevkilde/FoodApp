namespace FoodApp.API.Models.Domain
{
    public class FoodItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double ProteinPerHundredGrams { get; set; }
        public double CaloriesPerHundredGrams { get; set; }
        public double WeightInGrams { get; set; }
        public double Price { get; set; }
        public double Score { get; set; }

    }
}
    