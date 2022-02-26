using Linker.Application.Services.Commands;
using Linker.Application.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Linker.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkController : Controller
    {
        private readonly IMediator _mediator;

        public LinkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Test!");
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateAbrevationCommand command)
        {
            var result = await _mediator.Send(command);
            var hostUrl = ControllerContext.HttpContext.Request.Host.Value;

            return Ok(hostUrl + "/api/v1/Link/" + result.Abrevation);
        }

        [HttpGet("{abrevation}")]
        public async Task<ActionResult> Get(string abrevation)
        {
            var qeury = new GetUrlQuery() { Abrevation = abrevation };
            var result = await _mediator.Send(qeury);

            if (result == null)
            {
                return NotFound();
            }

            return Ok("Url is:" + result.Url);
        }

        [HttpGet("[Action]{abrevation}")]
        public async Task<ActionResult<int>> GetVisitCount(string abrevation)
        {
            var qeury = new GetVisitCountQuery() { Abrevation = abrevation };
            var result = await _mediator.Send(qeury);
            return Ok(result);
        }
    }
}
