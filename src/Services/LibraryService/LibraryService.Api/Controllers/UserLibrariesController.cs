using LibraryService.Application.Features.UserBooks.Commands.AddUserBookCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLibrariesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserLibrariesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddLibraryBook([FromBody] AddLibraryBookCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
