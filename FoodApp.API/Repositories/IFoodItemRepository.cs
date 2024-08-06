using FoodApp.API.Models.Domain;

namespace FoodApp.API.Repositories
{
    public interface IFoodItemRepository
    {
        Task<FoodItem> CreateAsync(FoodItem foodItem);
        Task<List<FoodItem>> GetAllAsync();
    }
}
