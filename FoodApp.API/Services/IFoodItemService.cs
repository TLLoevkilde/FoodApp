using FoodApp.API.Models.Domain;

namespace FoodApp.API.Services
{
    public interface IFoodItemService
    {
        Task<FoodItem> CreateAsync(FoodItem foodItem);
        Task<List<FoodItem>> GetAllAsync();
        
    }
}
