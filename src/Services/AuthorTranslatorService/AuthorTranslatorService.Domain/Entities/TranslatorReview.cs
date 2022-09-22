using AuthorTranslatorService.Domain.Abstraction.Entity;

namespace AuthorTranslatorService.Domain.Entities
{
    public class TranslatorReview : IEntity
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public Guid TranslatorId { get; set; }
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public Translator Translator { get; set; }
    }
}
