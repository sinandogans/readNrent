using BookService.Domain.Abstraction;
using BookService.Domain.Enums;

namespace BookService.Domain.Entities
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public Language Language { get; set; }
        public Publish Publish { get; set; }
        public ICollection<BookImage> BookImages { get; set; }
        public ICollection<BookReview> Reviews { get; set; }
    }
}
