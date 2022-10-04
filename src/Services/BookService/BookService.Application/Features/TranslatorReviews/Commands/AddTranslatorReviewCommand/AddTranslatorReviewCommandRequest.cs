using MediatR;

namespace BookService.Application.Features.TranslatorReviews.Commands.AddTranslatorReviewCommand
{
    public class AddTranslatorReviewCommandRequest : IRequest<AddTranslatorReviewCommandResponse>
    {
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public Guid TranslatorId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
