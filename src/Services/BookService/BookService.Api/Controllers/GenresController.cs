using BookService.Application.Features.Genres.Commands.AddGenreCommand;
using BookService.Application.Features.Genres.Commands.DeleteGenreCommand;
using BookService.Application.Features.Genres.Commands.UpdateGenreCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddGenreCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateGenreCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGenreCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
