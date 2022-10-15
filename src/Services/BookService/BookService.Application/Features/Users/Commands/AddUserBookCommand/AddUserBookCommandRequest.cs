using BookService.Application.Utilities.ResponseModel;
using BookService.Domain.Enums;
using MediatR;

namespace BookService.Application.Features.Users.Commands.AddUserBookCommand
{
    public class AddUserBookCommandRequest : IRequest<IResponseModel>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
    }
}
