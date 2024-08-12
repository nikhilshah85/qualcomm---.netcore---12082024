using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace shoppingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        [HttpGet]
        [Route("greetings")]
        public IActionResult GetGreetings()
        {
            //business logic
            return Ok("Hello and welcome to WebAPI development world");

        }

        [HttpGet]
        [Route("greetings/{userName}")]
        public IActionResult GetGreetings2(string userName)
        {
            if (userName.Length < 3) 
            {
                return BadRequest("Please pass a valid name");
            }
            return Ok("Hello " + userName);
        }
        [HttpGet]
        [Route("add/{num1}/{num2}")]
        public IActionResult GetAddNumbers(int num1, int num2) 
        {
                int result = num1 + num2;
                return Ok(result);
        }
    }
}
