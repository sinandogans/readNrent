using LibraryService.Domain.Abstraction;

namespace LibraryService.Domain.Entities
{
    public class TranslatorModel : IEntity
    {
        public TranslatorModel()
        {
            Books = new HashSet<Book>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
