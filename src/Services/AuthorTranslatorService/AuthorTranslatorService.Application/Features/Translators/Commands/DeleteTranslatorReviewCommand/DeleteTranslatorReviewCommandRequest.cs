using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Commands.DeleteTranslatorReviewCommand
{
    public class DeleteTranslatorReviewCommandRequest : IRequest<DeleteTranslatorReviewCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
