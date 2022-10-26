using AutoMapper;
using BookService.Application.Features.Books.Commands.AddBookCommand;
using BookService.Domain.AggregatesModel.BookAggregate;

namespace BookService.Application.Features.Books.MappingProfiles
{
    public class BooksProfiles : Profile
    {
        public BooksProfiles()
        {
            CreateMap<Book, AddBookCommandRequest>().ReverseMap();
        }
    }
}
