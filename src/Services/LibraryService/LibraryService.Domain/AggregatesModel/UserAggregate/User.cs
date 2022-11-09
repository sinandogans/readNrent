using LibraryService.Domain.Abstraction;
using LibraryService.Domain.AggregatesModel.LibraryAggregate;

namespace LibraryService.Domain.AggregatesModel.UserAggregate;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<LibraryBook> LibraryBooks { get; set; }
}