namespace FoodApp.API.Models.DTO
{
    public class FoodItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double ProteinPerHundredGrams { get; set; }
        public double CalPerHundredGrams { get; set; }
        public double WeightInGrams { get; set; }
        public double Price { get; set; }
        public double GramsOfProteinPerWeightInGrams { get; set; }
        public double CalPerHundredGramsOfProtein { get; set; }
        public double PricePerHundredGramsOfProtein { get; set; }
        public double Score { get; set; }

    }
}
