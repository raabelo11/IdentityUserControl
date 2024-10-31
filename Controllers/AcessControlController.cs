using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityUserControl.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessControlController : Controller
    {
        [HttpGet]
        [Authorize(Policy = "IdadeMinima")]
        public IActionResult Get()
        {
            return Ok("Access Allowed");
        }
    }
}
