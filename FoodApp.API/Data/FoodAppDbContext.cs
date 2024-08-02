using FoodApp.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.API.Data
{
    public class FoodAppDbContext: DbContext
    {
        public FoodAppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        // Tables that will be created in database
        public DbSet<FoodItem> FoodItems { get; set; }
    }
}
