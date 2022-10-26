using AutoMapper;
using BookService.Application.Features.BookImages.Commands.AddBookImageCommand;
using BookService.Domain.AggregatesModel.BookAggregate;

namespace BookService.Application.Features.BookImages.MappingProfiles
{
    public class BookImagesProfiles : Profile
    {
        public BookImagesProfiles()
        {
            CreateMap<BookImage, AddBookImageCommandRequest>().ReverseMap();
        }
    }
}
