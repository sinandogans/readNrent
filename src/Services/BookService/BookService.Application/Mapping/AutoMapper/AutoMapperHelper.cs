using AutoMapper;
using BookService.Application.Features.Books.Commands.AddAuthorToBookCommand;
using BookService.Application.Features.Books.Commands.AddBookCommand;
using BookService.Application.Features.Books.Commands.AddBookGenreCommand;
using BookService.Application.Features.Books.Commands.AddBookImageCommand;
using BookService.Application.Features.Books.Commands.AddBookPublishCommand;
using BookService.Application.Features.Books.Commands.AddBookReviewCommand;
using BookService.Application.Features.Books.Commands.AddTranslatorToBookCommand;
using BookService.Application.Features.Genres.Commands.AddGenreCommand;
using BookService.Application.Features.Languages.Commands.AddLanguageCommand;
using BookService.Application.Features.Publishers.Commands.AddPublisherCommand;
using BookService.Domain.Entities;

namespace BookService.Application.Mapping.AutoMapper
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Publisher, AddPublisherCommandRequest>().ReverseMap();
            CreateMap<Publisher, AddPublisherCommandResponse>().ReverseMap();

            CreateMap<Genre, AddGenreCommandRequest>().ReverseMap();
            CreateMap<Genre, AddGenreCommandResponse>().ReverseMap();


            //BOOK BEGİN
            CreateMap<Book, AddBookCommandRequest>().ReverseMap();
            CreateMap<Book, AddBookCommandResponse>().ReverseMap();

            CreateMap<Publish, AddPublishCommandRequest>().ReverseMap();
            CreateMap<Publish, AddPublishCommandResponse>().ReverseMap();

            CreateMap<BookImage, AddBookImageCommandRequest>().ReverseMap();
            CreateMap<BookImage, AddBookImageCommandResponse>().ReverseMap();

            CreateMap<BookReview, AddBookReviewCommandRequest>().ReverseMap();
            CreateMap<BookReview, AddBookReviewCommandResponse>().ReverseMap();

            CreateMap<Book, AddGenreToBookCommandResponse>().ReverseMap();

            CreateMap<Book, AddAuthorToBookCommandResponse>().ReverseMap();

            CreateMap<Book, AddTranslatorToBookCommandResponse>().ReverseMap();

            //BOOK AND


            //LANGUAGE BEGİN
            CreateMap<Language, AddLanguageCommandRequest>().ReverseMap();
            CreateMap<Language, AddLanguageCommandResponse>().ReverseMap();
            //LANGUAGE END

        }
    }
}
