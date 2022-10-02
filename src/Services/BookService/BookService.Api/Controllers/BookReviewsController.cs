using BookService.Application.Features.BookReviews.Commands.AddBookReviewCommand;
using BookService.Application.Features.BookReviews.Commands.DeleteBookReviewCommand;
using BookService.Application.Features.BookReviews.Commands.UpdateBookReviewCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddBookReviewCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBookReviewCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateBookReviewCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
