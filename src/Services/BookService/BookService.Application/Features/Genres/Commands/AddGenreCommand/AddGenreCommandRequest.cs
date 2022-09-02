using MediatR;

namespace BookService.Application.Features.Genres.Commands.AddGenreCommand
{
    public class AddGenreCommandRequest : IRequest<AddGenreCommandResponse>
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}
