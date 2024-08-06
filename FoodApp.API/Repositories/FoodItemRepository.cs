using FoodApp.API.Data;
using FoodApp.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.API.Repositories
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly FoodAppDbContext dbContext;

        public FoodItemRepository(FoodAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<FoodItem> CreateAsync(FoodItem foodItem)
        {
            await dbContext.FoodItems.AddAsync(foodItem);
            await dbContext.SaveChangesAsync();
            return foodItem;
        }

        public async Task<List<FoodItem>> GetAllAsync()
        {
            return await dbContext.FoodItems.ToListAsync();
        }
    }
}
