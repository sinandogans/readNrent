using LibraryService.Domain.Abstraction;

namespace LibraryService.Domain.AggregatesModel.LibraryAggregate;

public class Book:IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public double Rating { get; set; }
    public ICollection<Author> Authors { get; set; }
}