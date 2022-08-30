using AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthorTranslatorService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddTranslatorCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
