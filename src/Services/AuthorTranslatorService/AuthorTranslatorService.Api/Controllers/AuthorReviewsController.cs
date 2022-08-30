using AuthorTranslatorService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthorTranslatorService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddAuthorReviewCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
