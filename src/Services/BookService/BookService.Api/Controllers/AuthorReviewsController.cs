using BookService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand;
using BookService.Application.Features.AuthorReviews.Commands.DeleteAuthorReviewCommand;
using BookService.Application.Features.AuthorReviews.Commands.UpdateAuthorReviewCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Api.Controllers
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
        public async Task<IActionResult> Add([FromBody] AddAuthorReviewCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteAuthorReviewCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorReviewCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
