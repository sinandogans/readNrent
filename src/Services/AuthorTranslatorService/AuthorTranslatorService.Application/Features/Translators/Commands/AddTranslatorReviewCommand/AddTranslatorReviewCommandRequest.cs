using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorReviewCommand
{
    public class AddTranslatorReviewCommandRequest : IRequest<AddTranslatorReviewCommandResponse>
    {
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public Guid TranslatorId { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
    }
}
