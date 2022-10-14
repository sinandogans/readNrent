using LibraryService.API.LibraryService.Domain.Abstraction;

namespace LibraryService.API.LibraryService.Domain.Entities
{
    public class Reader : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
