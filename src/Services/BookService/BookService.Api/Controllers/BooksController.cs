using BookService.Application.Features.Books.Commands.AddAuthorToBookCommand;
using BookService.Application.Features.Books.Commands.AddBookCommand;
using BookService.Application.Features.Books.Commands.AddBookImageCommand;
using BookService.Application.Features.Books.Commands.AddBookReviewCommand;
using BookService.Application.Features.Books.Commands.AddGenreToBookCommand;
using BookService.Application.Features.Books.Commands.AddPublishCommand;
using BookService.Application.Features.Books.Commands.AddTranslatorToBookCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddBookCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("addpublish")]
        public async Task<IActionResult> AddPublish(AddPublishCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("addauthor")]
        public async Task<IActionResult> AddAuthor(AddAuthorToBookCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("addtranslator")]
        public async Task<IActionResult> AddTranslator(AddTranslatorToBookCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("addgenre")]
        public async Task<IActionResult> AddGenre(AddGenreToBookCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("addreview")]
        public async Task<IActionResult> AddReview(AddBookReviewCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("addimage")]
        public async Task<IActionResult> AddImage([FromForm] AddBookImageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
