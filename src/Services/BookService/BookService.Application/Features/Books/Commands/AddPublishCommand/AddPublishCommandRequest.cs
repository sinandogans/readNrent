using MediatR;

namespace BookService.Application.Features.Books.Commands.AddPublishCommand
{
    public class AddPublishCommandRequest : IRequest<AddPublishCommandResponse>
    {
        public Guid PublisherId { get; set; }
        public Guid BookId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
