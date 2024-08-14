using FoodApp.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.UI.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public FoodItemController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<FoodItemDto> FoodItems =new List<FoodItemDto>();

            try
            {
                var client = httpClientFactory.CreateClient(); // Creates a new client

                var httpResponseMessage = await client.GetAsync("https://localhost:7192/api/fooditem"); // Gets data using backend url

                httpResponseMessage.EnsureSuccessStatusCode();

                FoodItems.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<FoodItemDto>>()); // FoodItems is added to the list
            }
            catch (Exception ex)
            {

                throw;
            }


            return View(FoodItems);  // FoodItem list is added to the View
        }
    }
}
