using BookService.Domain.Abstraction;

namespace BookService.Domain.Entities
{
    public class Genre : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public Genre Parent { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Genre> SubGenres { get; set; }
    }
}