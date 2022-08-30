namespace AuthorTranslatorService.Application.Features.TranslatorReviews.Queries.GetTranslatorReviewsByUserIdQuery
{
    public class GetTranslatorReviewsByUserIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public Guid TranslatorId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
    }
}
