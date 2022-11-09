using LibraryService.Domain.Abstraction;
using LibraryService.Domain.AggregatesModel.UserAggregate;
using LibraryService.Domain.Enums;

namespace LibraryService.Domain.AggregatesModel.LibraryAggregate;

public class LibraryBook : IEntity
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
    public int UserRating { get; set; }
    public ReadStatus Status { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateRead { get; set; }

    public Book Book { get; set; }
    public User User { get; set; }
}