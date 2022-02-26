using Microsoft.AspNetCore.Mvc;

namespace Linker.WebApi.Controllers
{
    public class LinkController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Test");
        }
    }
}
