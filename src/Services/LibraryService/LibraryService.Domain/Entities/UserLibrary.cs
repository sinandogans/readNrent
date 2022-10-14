using LibraryService.Domain.Abstraction;

namespace LibraryService.Domain.Entities
{
    public class UserLibrary : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ICollection<LibraryBook> LibraryBooks { get; set; }
    }
}
