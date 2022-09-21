using BookService.Application.Features.Languages.Commands.AddLanguageCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LanguagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddLanguageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
