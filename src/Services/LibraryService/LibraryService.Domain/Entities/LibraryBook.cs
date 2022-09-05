using LibraryService.Domain.Abstraction;
using LibraryService.Domain.Enums;

namespace LibraryService.Domain.Entities
{
    public class LibraryBook : IEntity
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Status Status { get; set; }
        public int UserRating { get; set; }
        public UserLibrary UserLibrary { get; set; }
    }
}
