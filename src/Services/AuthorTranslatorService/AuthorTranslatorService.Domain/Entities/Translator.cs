using AuthorTranslatorService.Domain.Abstraction.Entity;

namespace AuthorTranslatorService.Domain.Entities
{
    public class Translator : IEntity
    {
        public Translator()
        {
            Reviews = new HashSet<TranslatorReview>();
            Books = new HashSet<BookModel>();
        }
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public double? Rating { get; set; }
        public int ReviewCount { get; set; }
        public ICollection<TranslatorReview> Reviews { get; set; }
        public ICollection<BookModel> Books { get; set; }
    }
}
