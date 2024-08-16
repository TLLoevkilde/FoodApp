using AutoMapper;
using FoodApp.API.Models.Domain;
using FoodApp.API.Models.DTO;
using FoodApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly IFoodItemService foodItemService;
        private readonly IMapper mapper;

        public FoodItemController(IFoodItemService foodItemService, IMapper mapper)
        {
            this.foodItemService = foodItemService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFoodItemDto createFoodItemDto)
        {
            // Map to Domain Model
            var foodItem = mapper.Map<FoodItem>(createFoodItemDto);

            // Store Domain Model in Database
            await foodItemService.CreateAsync(foodItem);

            // Return DTO
            return Ok(mapper.Map<FoodItemDto>(foodItem));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get items from database
            List<FoodItem> foodItems = await foodItemService.GetAllAsync();

            // Return DTO
            return Ok(mapper.Map<List<FoodItemDto>>(foodItems));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var foodItem = await foodItemService.GetByIdAsync(id);

            if (foodItem == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<FoodItemDto>(foodItem));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFoodItemDto updateFoodItemDto)
        {
            var foodItem = mapper.Map<FoodItem>(updateFoodItemDto);
            foodItem.Id = id;

            var updatedFoodItem = await foodItemService.UpdateAsync(foodItem);

            if (updatedFoodItem == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<FoodItemDto>(updatedFoodItem));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedFoodItem = await foodItemService.DeleteAsync(id);

            if (deletedFoodItem == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<FoodItemDto>(deletedFoodItem));
        }
    }
}
