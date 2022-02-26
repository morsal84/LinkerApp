using Microsoft.AspNetCore.Mvc;

namespace Linker.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkController : Controller
    {
        //public LinkController(IMediatr mediatr)
        //{

        //}
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Test");
        }
    }
}
