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
            // Business logic calculations
            SetCalculatedFields(foodItem);

            return await foodItemRepository.CreateAsync(foodItem);
        }

        public async Task<List<FoodItem>> GetAllAsync()
        {
            return await foodItemRepository.GetAllAsync();
        }

        public async Task<FoodItem?> GetByIdAsync(Guid id)
        {
            return await foodItemRepository.GetByIdAsync(id);
        }

        public async Task<FoodItem?> UpdateAsync(FoodItem foodItem)
        {
            var existingFoodItem = await foodItemRepository.GetByIdAsync(foodItem.Id);

            if (existingFoodItem == null)
            {
                return null;
            }

            // Apply updates
            existingFoodItem.Name = foodItem.Name;
            existingFoodItem.WeightInGrams = foodItem.WeightInGrams;
            existingFoodItem.Price = foodItem.Price;
            existingFoodItem.ProteinPerHundredGrams = foodItem.ProteinPerHundredGrams;

            // Business logic calculations
            SetCalculatedFields(existingFoodItem);

            return await foodItemRepository.UpdateAsync(existingFoodItem);
        }

        public async Task<FoodItem?> DeleteAsync(Guid id)
        {
            return await foodItemRepository.DeleteAsync(id);
        }

        private void SetCalculatedFields(FoodItem foodItem)
        {
            foodItem.ProteinPerWeightInGrams = foodItem.ProteinPerHundredGrams * foodItem.WeightInGrams / 100;
            foodItem.CalPerHundredGramsOfProtein = (int)Math.Round(100 / foodItem.ProteinPerHundredGrams * foodItem.CalPerHundredGrams);
            foodItem.PricePerHundredGramsOfProtein = Math.Round(100 / foodItem.ProteinPerWeightInGrams * foodItem.Price, 2);
            foodItem.Score = (int)Math.Round(foodItem.PricePerHundredGramsOfProtein * foodItem.CalPerHundredGramsOfProtein);
        }
    }
}
