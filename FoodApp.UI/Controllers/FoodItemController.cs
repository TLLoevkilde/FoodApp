using FoodApp.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FoodApp.UI.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public FoodItemController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder)
        {
            List<FoodItemDto> foodItems = new List<FoodItemDto>();

            try
            {
                var client = httpClientFactory.CreateClient(); // Creates a new client

                var httpResponseMessage = await client.GetAsync("https://localhost:7192/api/fooditem"); // Gets data using backend url

                httpResponseMessage.EnsureSuccessStatusCode();

                foodItems = (await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<FoodItemDto>>()).ToList(); // Convert to List
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, rethrow it, etc.)
                throw;
            }

            // Sort the list based on sortOrder
            switch (sortOrder)
            {
                case "pricePerProtein":
                    foodItems = foodItems.OrderBy(f => f.PricePerHundredGramsOfProtein).ToList();
                    break;
                case "caloriesPerProtein":
                    foodItems = foodItems.OrderBy(f => f.CalPerHundredGramsOfProtein).ToList();
                    break;
                case "score":
                    foodItems = foodItems.OrderBy(f => f.Score).ToList();
                    break;
                default:
                    // Default to sorting by PricePerHundredGramsOfProtein ascending
                    foodItems = foodItems.OrderBy(f => f.PricePerHundredGramsOfProtein).ToList();
                    break;
            }

            // Pass the sorted list and current sort order to the view
            ViewBag.CurrentSort = sortOrder;
            return View(foodItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFoodItemDto createFoodItemDto)
        {
            if (ModelState.IsValid)
            {
                var client = httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7192/api/fooditem", createFoodItemDto);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(createFoodItemDto);
        }

        // GET: Load the existing food item to edit
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7192/api/fooditem/{id}");

            if (response.IsSuccessStatusCode)
            {
                var foodItem = await response.Content.ReadFromJsonAsync<UpdateFoodItemDto>();
                return View(foodItem);
            }

            return NotFound();
        }

        // POST: Update the food item
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UpdateFoodItemDto updateFoodItemDto)
        {
            if (ModelState.IsValid)
            {
                var client = httpClientFactory.CreateClient();
                var response = await client.PutAsJsonAsync($"https://localhost:7192/api/fooditem/{id}", updateFoodItemDto);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(updateFoodItemDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7192/api/fooditem/{id}");

            if (response.IsSuccessStatusCode)
            {
                var foodItem = await response.Content.ReadFromJsonAsync<FoodItemDto>();
                return View(foodItem);
            }

            return NotFound();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7192/api/fooditem/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }





    }
}
