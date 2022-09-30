using AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorCommand;
using AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorReviewCommand;
using AuthorTranslatorService.Application.Features.Authors.Commands.DeleteAuthorCommand;
using AuthorTranslatorService.Application.Features.Authors.Commands.DeleteAuthorReviewCommand;
using AuthorTranslatorService.Application.Features.Authors.Commands.UpdateAuthorCommand;
using AuthorTranslatorService.Application.Features.Authors.Commands.UpdateAuthorReviewCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
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
