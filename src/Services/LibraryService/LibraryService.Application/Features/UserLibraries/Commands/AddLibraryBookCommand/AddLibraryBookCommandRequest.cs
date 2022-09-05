using LibraryService.Domain.Enums;
using MediatR;

namespace LibraryService.Application.Features.UserBooks.Commands.AddUserBookCommand
{
    public class AddLibraryBookCommandRequest : IRequest<AddLibraryBookCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Status Status { get; set; }
        public int? UserRating { get; set; }
    }
}
