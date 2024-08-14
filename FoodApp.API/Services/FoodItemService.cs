using FoodApp.API.Models.Domain;
using FoodApp.API.Repositories;

namespace FoodApp.API.Services
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IFoodItemRepository foodItemRepository;

        public FoodItemService(IFoodItemRepository foodItemRepository)
        {
            this.foodItemRepository = foodItemRepository;
        }
        public async Task<FoodItem> CreateAsync(FoodItem foodItem)
        {
            foodItem.ProteinPerWeightInGrams = foodItem.ProteinPerHundredGrams * foodItem.WeightInGrams / 100;
            foodItem.CalPerHundredGramsOfProtein = (int)Math.Round(100 / foodItem.ProteinPerHundredGrams * foodItem.CalPerHundredGrams);
            foodItem.PricePerHundredGramsOfProtein = Math.Round(100 / foodItem.ProteinPerWeightInGrams * foodItem.Price,2);
            foodItem.Score = (int)Math.Round(foodItem.PricePerHundredGramsOfProtein * foodItem.CalPerHundredGramsOfProtein);

            await foodItemRepository.CreateAsync(foodItem);
            return foodItem;
        }

        public async Task<List<FoodItem>> GetAllAsync()
        {
            return await foodItemRepository.GetAllAsync();
        }
    }
}
