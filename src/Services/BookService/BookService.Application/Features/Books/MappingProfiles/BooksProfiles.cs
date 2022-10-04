using AutoMapper;
using BookService.Application.Features.Books.Commands.AddBookCommand;
using BookService.Domain.Entities;

namespace BookService.Application.Features.Books.MappingProfiles
{
    public class BooksProfiles : Profile
    {
        public BooksProfiles()
        {
            CreateMap<BookFeature, AddBookCommandRequest>().ReverseMap();
        }
    }
}
