using MediatR;

namespace BookService.Application.Features.TranslatorReviews.Commands.DeleteTranslatorReviewCommand
{
    public class DeleteTranslatorReviewCommandRequest : IRequest<DeleteTranslatorReviewCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
