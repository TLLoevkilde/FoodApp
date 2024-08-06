using FoodApp.API.Models.Domain;
using FoodApp.API.Services;
using Microsoft.AspNetCore.Mvc;


namespace FoodApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly IFoodItemService foodItemService;

        public FoodItemController(IFoodItemService foodItemService)
        {
            this.foodItemService = foodItemService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FoodItem foodItem)
        {
            await foodItemService.CreateAsync(foodItem);
            return Ok(foodItem);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<FoodItem> foodItems = await foodItemService.GetAllAsync();
            return Ok(foodItems);
        }

        
    }
}
