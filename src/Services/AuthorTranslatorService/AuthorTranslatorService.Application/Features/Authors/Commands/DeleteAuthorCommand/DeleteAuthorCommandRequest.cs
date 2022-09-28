using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommandRequest : IRequest<DeleteAuthorCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
