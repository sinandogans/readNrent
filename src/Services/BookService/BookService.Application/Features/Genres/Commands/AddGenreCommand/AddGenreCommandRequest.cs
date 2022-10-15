using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Genres.Commands.AddGenreCommand
{
    public class AddGenreCommandRequest : IRequest<IResponseModel>
    {
        public string Name { get; set; }
        public Guid ParentId { get; set; } = default;
    }
}
