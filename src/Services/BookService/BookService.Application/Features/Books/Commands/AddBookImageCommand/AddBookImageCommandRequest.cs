using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookService.Application.Features.Books.Commands.AddBookImageCommand
{
    public class AddBookImageCommandRequest : IRequest<AddBookImageCommandResponse>
    {
        public IFormFile Image { get; set; }
        public Guid BookId { get; set; }
    }
}
