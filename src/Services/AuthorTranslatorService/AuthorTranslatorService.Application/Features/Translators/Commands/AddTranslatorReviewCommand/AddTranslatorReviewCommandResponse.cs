namespace AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorReviewCommand
{
    public class AddTranslatorReviewCommandResponse
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public Guid TranslatorId { get; set; }
        public Guid UserId { get; set; }
        public string? Username { get; set; }
    }
}
