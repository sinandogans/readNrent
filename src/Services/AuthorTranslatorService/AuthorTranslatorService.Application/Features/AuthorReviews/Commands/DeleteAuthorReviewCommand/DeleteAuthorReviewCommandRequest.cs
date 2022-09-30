using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.DeleteAuthorReviewCommand
{
    public class DeleteAuthorReviewCommandRequest : IRequest<DeleteAuthorReviewCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
