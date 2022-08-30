using AuthorTranslatorService.Domain.Abstraction.Entity;

namespace AuthorTranslatorService.Domain.Entities
{
    public class AuthorReview : IEntity
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public Guid AuthorId { get; set; }
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public Author Author { get; set; }
    }
}
