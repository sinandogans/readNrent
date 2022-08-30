using AuthorTranslatorService.Domain.Abstraction.Entity;

namespace AuthorTranslatorService.Domain.Entities
{
    public class BookModel : IEntity
    {
        public Guid BookId { get; set; }
        public double Rating { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Translator> Translators { get; set; }
    }
}
