using MediatR;

namespace BookService.Application.Features.TranslatorReviews.Commands.UpdateTranslatorReviewCommand
{
    public class UpdateTranslatorReviewCommandRequest : IRequest<UpdateTranslatorReviewCommandResponse>
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
        public double? Rating { get; set; }
    }
}
