using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new string[] {"Kylling", "Bacon"});
        }
    }
}
