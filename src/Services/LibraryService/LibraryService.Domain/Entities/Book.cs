using LibraryService.Domain.Abstraction;

namespace LibraryService.Domain.Entities
{
    public class Book : IEntity
    {
        public Book()
        {
            LibraryBooks = new HashSet<LibraryBook>();
            Authors = new HashSet<AuthorModel>();
            Translators = new HashSet<TranslatorModel>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string ImagePath { get; set; }
        public ICollection<LibraryBook> LibraryBooks { get; set; }
        public ICollection<AuthorModel> Authors { get; set; }
        public ICollection<TranslatorModel> Translators { get; set; }
    }
}
