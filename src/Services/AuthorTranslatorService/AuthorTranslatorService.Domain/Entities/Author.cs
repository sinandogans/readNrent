using AuthorTranslatorService.Domain.Abstraction.Entity;

namespace AuthorTranslatorService.Domain.Entities
{
    public class Author : IEntity
    {
        public Author()
        {
            Reviews = new HashSet<AuthorReview>();
            Books = new HashSet<BookModel>();
        }
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        public ICollection<AuthorReview> Reviews { get; set; }
        public ICollection<BookModel> Books { get; set; }
    }
}
