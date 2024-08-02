using FoodApp.API.Data;
using FoodApp.API.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly FoodAppDbContext dbContext;

        public FoodItemController(FoodAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FoodItem foodItem)
        {
            dbContext.FoodItems.Add(foodItem);
            await dbContext.SaveChangesAsync();
            return Ok(foodItem);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<FoodItem> foodItems = await dbContext.FoodItems.ToListAsync();
            return Ok(foodItems);
        }

        
    }
}
