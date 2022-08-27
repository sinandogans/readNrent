using AuthorTranslatorService.Domain.Abstraction.Entity;

namespace AuthorTranslatorService.Domain.Entities
{
    public class Author : IEntity
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<AuthorReview> Reviews { get; set; }
    }
}
