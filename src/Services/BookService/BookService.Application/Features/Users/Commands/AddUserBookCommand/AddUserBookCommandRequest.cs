using BookService.Domain.Enums;
using MediatR;

namespace BookService.Application.Features.Users.Commands.AddUserBookCommand
{
    public class AddUserBookCommandRequest : IRequest<AddUserBookCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BeginDate { get; set; } = default;
        public DateTime EndDate { get; set; } = default;
        public Status Status { get; set; } = 0;
        public int Rating { get; set; }
    }
}
