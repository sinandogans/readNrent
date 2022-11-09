using AutoMapper;
using LibraryService.Application.IntegrationEvents.BookService.Books.BookAdded;
using LibraryService.Domain.AggregatesModel.LibraryAggregate;

namespace LibraryService.Application.IntegrationEvents.BookService.Books;

public class BookProfiles : Profile
{
    public BookProfiles()
    {
        CreateMap<BookAddedIntegrationEvent, Book>()
            .ForMember(book => book.Id, opt => opt.MapFrom(e => e.BookId));
    }
}