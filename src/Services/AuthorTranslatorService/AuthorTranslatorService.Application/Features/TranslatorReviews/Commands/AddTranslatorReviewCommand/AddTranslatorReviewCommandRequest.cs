using MediatR;

namespace AuthorTranslatorService.Application.Features.TranslatorReviews.Commands.AddTranslatorReviewCommand
{
    public class AddTranslatorReviewCommandRequest : IRequest<AddTranslatorReviewCommandResponse>
    {
        public string Comment { get; set; }
        public double Rating { get; set; }
        public Guid TranslatorId { get; set; }
        public Guid UserId { get; set; }
    }
}
