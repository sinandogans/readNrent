using LibraryService.Domain.Abstraction;

namespace LibraryService.Domain.Entities
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string ImagePath { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public Guid? TranslatorId { get; set; }
        public string? TranslatorName { get; set; }
        public ICollection<LibraryBook> LibraryBooks { get; set; }
    }
}
