using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
