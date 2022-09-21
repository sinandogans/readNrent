using BookService.Application.Features.Publishers.Commands.AddPublisherCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PublishersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddPublisherCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
