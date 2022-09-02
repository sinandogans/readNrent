using AutoMapper;
using BookService.Application.Features.Books.Commands.AddBookCommand;
using BookService.Application.Features.Books.Commands.AddBookPublishCommand;
using BookService.Application.Features.Books.Commands.AddBookReviewCommand;
using BookService.Application.Features.Genres.Commands.AddGenreCommand;
using BookService.Application.Features.Publishers.Commands.AddPublisherCommand;
using BookService.Domain.Entities;

namespace BookService.Application.Mapping.AutoMapper
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Book, AddBookCommandRequest>().ReverseMap();
            CreateMap<Book, AddBookCommandResponse>().ReverseMap();

            CreateMap<BookReview, AddBookReviewCommandRequest>().ReverseMap();
            CreateMap<BookReview, AddBookReviewCommandResponse>().ReverseMap();

            CreateMap<Publish, AddBookPublishCommandRequest>().ReverseMap();
            CreateMap<Publish, AddBookPublishCommandResponse>().ReverseMap();

            CreateMap<Publisher, AddPublisherCommandRequest>().ReverseMap();
            CreateMap<Publisher, AddPublisherCommandResponse>().ReverseMap();

            CreateMap<Genre, AddGenreCommandRequest>().ReverseMap();
            CreateMap<Genre, AddGenreCommandResponse>().ReverseMap();
        }
    }
}
