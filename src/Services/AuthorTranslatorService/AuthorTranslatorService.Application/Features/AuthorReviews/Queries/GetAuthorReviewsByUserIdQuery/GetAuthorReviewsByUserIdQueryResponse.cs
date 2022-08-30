namespace AuthorTranslatorService.Application.Features.AuthorReviews.Queries.GetAuthorReviewsByUserIdQuery
{
    public class GetAuthorReviewsByUserIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public Guid AuthorId { get; set; }
        public Guid UserId { get; set; }
    }
}
