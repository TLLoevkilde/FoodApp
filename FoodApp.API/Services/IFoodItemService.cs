using FoodApp.API.Models.Domain;

namespace FoodApp.API.Services
{
    public interface IFoodItemService
    {
        Task<FoodItem> CreateAsync(FoodItem foodItem);
        Task<List<FoodItem>> GetAllAsync();
        Task<FoodItem?> GetByIdAsync(Guid id);
        Task<FoodItem?> UpdateAsync(FoodItem foodItem);
        Task<FoodItem?> DeleteAsync(Guid id);
    }
}
