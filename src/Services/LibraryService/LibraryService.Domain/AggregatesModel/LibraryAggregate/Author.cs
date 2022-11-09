using LibraryService.Domain.Abstraction;

namespace LibraryService.Domain.AggregatesModel.LibraryAggregate;

public class Author:IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Book> Books { get; set; }
}