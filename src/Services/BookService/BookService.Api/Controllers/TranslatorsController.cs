using BookService.Application.Features.Translators.Commands.AddTranslatorCommand;
using BookService.Application.Features.Translators.Commands.DeleteTranslatorCommand;
using BookService.Application.Features.Translators.Commands.UpdateTranslatorCommand;
using BookService.Application.Features.Translators.Queries.GetAllTranslatorsQuery;
using BookService.Application.Features.Translators.Queries.GetTranslatorByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Api.Controllers
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

        [HttpGet("getbyid/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetTranslatorByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromRoute] GetAllTranslatorsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTranslatorCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTranslatorCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
