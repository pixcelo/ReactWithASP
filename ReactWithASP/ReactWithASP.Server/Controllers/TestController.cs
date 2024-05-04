using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello world.");
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginModel model)
        {
            try
            {
                var token = "test-token";
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest("Login failed: " + ex.Message);
            }
        }
    }
}
