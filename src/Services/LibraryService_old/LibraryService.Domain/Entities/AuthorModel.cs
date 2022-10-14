using LibraryService.Domain.Abstraction;

namespace LibraryService.Domain.Entities
{
    public class AuthorModel : IEntity
    {
        public AuthorModel()
        {
            Books = new HashSet<Book>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
