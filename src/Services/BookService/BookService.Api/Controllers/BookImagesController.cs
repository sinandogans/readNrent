using BookService.Application.Features.BookImages.Commands.AddBookImageCommand;
using BookService.Application.Features.BookImages.Commands.DeleteBookImageCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add/{BookId}")]
        public async Task<IActionResult> Add([FromRoute][FromForm] AddBookImageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBookImageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        //[HttpPost("update")]
        //public async Task<IActionResult> Update([FromBody] UpdateBookReviewCommandRequest request)
        //{
        //    var response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}
