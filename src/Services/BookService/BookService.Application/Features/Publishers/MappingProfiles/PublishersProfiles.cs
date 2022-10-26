using AutoMapper;
using BookService.Application.Features.Publishers.Commands.AddPublisherCommand;
using BookService.Domain.AggregatesModel.BookAggregate;

namespace BookService.Application.Features.Publishers.MappingProfiles
{
    public class PublishersProfiles : Profile
    {
        public PublishersProfiles()
        {
            CreateMap<Publisher, AddPublisherCommandRequest>().ReverseMap();
        }
    }
}
