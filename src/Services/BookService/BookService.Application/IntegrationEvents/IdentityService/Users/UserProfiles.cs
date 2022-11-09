using AutoMapper;
using BookService.Application.IntegrationEvents.IdentityService.Users.UserRegistered;
using BookService.Application.IntegrationEvents.IdentityService.Users.UserUpdated;
using BookService.Domain.AggregatesModel.UserAggregate;

namespace BookService.Application.IntegrationEvents.IdentityService.Users;

public class UserProfiles : Profile
{
    public UserProfiles()
    {
        CreateMap<UserRegisteredIntegrationEvent, User>()
            .ForMember(usr => usr.Id, opt => opt.MapFrom(e => e.UserId));
        CreateMap<UserUpdatedIntegrationEvent, User>()
            .ForMember(usr => usr.Id, opt => opt.MapFrom(e => e.UserId));
    }
}