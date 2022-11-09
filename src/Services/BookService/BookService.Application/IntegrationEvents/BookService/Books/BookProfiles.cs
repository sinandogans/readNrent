using AutoMapper;
using BookService.Application.IntegrationEvents.BookService.Books.BookAdded;
using BookService.Domain.AggregatesModel.BookAggregate;

namespace BookService.Application.IntegrationEvents.BookService.Books;

public class BookProfiles : Profile
{
    public BookProfiles()
    {
        CreateMap<BookAddedIntegrationEvent, Book>()
            .ForMember(book => book.Id, opt => opt.MapFrom(e => e.BookId)).ReverseMap();
    }
}