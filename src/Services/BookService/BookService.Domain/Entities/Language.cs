using BookService.Domain.Abstraction;

namespace BookService.Domain.Entities
{
    public class Language : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
