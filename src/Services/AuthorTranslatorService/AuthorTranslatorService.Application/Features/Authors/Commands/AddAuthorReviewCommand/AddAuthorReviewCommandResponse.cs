namespace AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorReviewCommand
{
    public class AddAuthorReviewCommandResponse
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public Guid AuthorId { get; set; }
        public Guid UserId { get; set; }
        public string? Username { get; set; }
    }
}
