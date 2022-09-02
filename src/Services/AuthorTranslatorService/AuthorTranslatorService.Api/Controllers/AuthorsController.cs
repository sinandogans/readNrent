using AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorCommand;
using AuthorTranslatorService.Application.Features.Authors.Queries.GetAllAuthorsQuery;
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
        public async Task<IActionResult> Add([FromBody] AddAuthorCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(GetAllAuthorsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
