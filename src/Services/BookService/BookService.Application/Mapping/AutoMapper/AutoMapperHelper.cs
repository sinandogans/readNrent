using AutoMapper;
using BookService.Application.Features.Books.Commands.AddBookCommand;
using BookService.Application.Features.Books.Commands.AddBookPublishCommand;
using BookService.Application.Features.Books.Commands.AddBookReviewCommand;
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
        }
    }
}
