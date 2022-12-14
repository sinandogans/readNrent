using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookCommand
{
    public class AddBookCommandRequest : IRequest<IResponseModel>
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public List<Guid> AuthorIds { get; set; }
        public List<Guid> GenreIds { get; set; }
    }
}
