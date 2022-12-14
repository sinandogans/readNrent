using AutoMapper;
using BookService.Application.Features.Publishes.Commands.AddPublishCommand;
using BookService.Domain.AggregatesModel.BookAggregate;

namespace BookService.Application.Features.Publishes.MappingProfiles
{
    public class PublishesProfiles : Profile
    {
        public PublishesProfiles()
        {
            CreateMap<Publish, AddPublishCommandRequest>().ReverseMap();
        }
    }
}
