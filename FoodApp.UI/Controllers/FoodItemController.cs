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
    }
}
