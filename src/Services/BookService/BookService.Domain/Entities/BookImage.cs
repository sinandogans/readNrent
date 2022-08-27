using BookService.Domain.Abstraction;

namespace BookService.Domain.Entities
{
    public class BookImage : IEntity
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}