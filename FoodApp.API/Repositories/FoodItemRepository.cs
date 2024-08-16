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

        public async Task<FoodItem?> GetByIdAsync(Guid id)
        {
            return await dbContext.FoodItems.FindAsync(id);
        }

        public async Task<FoodItem?> UpdateAsync(FoodItem foodItem)
        {
            var existingFoodItem = await dbContext.FoodItems.FindAsync(foodItem.Id);

            if (existingFoodItem == null)
            {
                return null;
            }

            await dbContext.SaveChangesAsync();
            return existingFoodItem;
        }

        public async Task<FoodItem?> DeleteAsync(Guid id)
        {
            var existingFoodItem = await dbContext.FoodItems.FindAsync(id);

            if (existingFoodItem == null)
            {
                return null;
            }

            dbContext.FoodItems.Remove(existingFoodItem);
            await dbContext.SaveChangesAsync();
            return existingFoodItem;
        }
    }
}
