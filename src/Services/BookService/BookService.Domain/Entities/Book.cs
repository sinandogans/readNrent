using BookService.Domain.Abstraction;

namespace BookService.Domain.Entities
{
    public class Book : IEntity
    {
        public Book()
        {
            BookImages = new HashSet<BookImage>();
            Reviews = new HashSet<BookReview>();
            Genres = new HashSet<Genre>();
        }
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public Guid PublishId { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public Language Language { get; set; }
        public Publish Publish { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<BookImage> BookImages { get; set; }
        public ICollection<BookReview> Reviews { get; set; }
    }
}
