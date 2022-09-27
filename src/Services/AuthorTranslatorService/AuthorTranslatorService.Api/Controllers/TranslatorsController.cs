using AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorCommand;
using AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorReviewCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthorTranslatorService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TranslatorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddTranslatorCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("addreview")]
        public async Task<IActionResult> AddReview([FromBody] AddTranslatorReviewCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
