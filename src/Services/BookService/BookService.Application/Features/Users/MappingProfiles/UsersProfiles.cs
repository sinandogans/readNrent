using AutoMapper;
using BookService.Application.Features.Users.Commands.AddUserBookCommand;
using BookService.Application.IntegrationEvents.IdentityService.Users.UserRegistered;
using BookService.Application.IntegrationEvents.IdentityService.Users.UserUpdated;
using BookService.Domain.Entities;

namespace BookService.Application.Features.Users.MappingProfiles
{
    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            CreateMap<UserBook, AddUserBookCommandRequest>().ReverseMap();
            CreateMap<UserRegisteredIntegrationEvent, User>()
                .ForMember(usr => usr.Id, opt => opt.MapFrom(evnt => evnt.UserId));
            CreateMap<UserUpdatedIntegrationEvent, User>()
                .ForMember(usr => usr.Id, opt => opt.MapFrom(evnt => evnt.UserId));
        }
    }
}
