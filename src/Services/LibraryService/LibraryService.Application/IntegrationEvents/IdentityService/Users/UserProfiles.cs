using AutoMapper;
using LibraryService.Application.IntegrationEvents.IdentityService.Users.UserRegistered;
using LibraryService.Application.IntegrationEvents.IdentityService.Users.UserUpdated;
using LibraryService.Domain.AggregatesModel.UserAggregate;

namespace LibraryService.Application.IntegrationEvents.IdentityService.Users;

public class UserProfiles : Profile
{
    public UserProfiles()
    {
        CreateMap<UserRegisteredIntegrationEvent, User>()
            .ForMember(usr => usr.Id, opt => opt.MapFrom(evnt => evnt.UserId));
        CreateMap<UserUpdatedIntegrationEvent, User>()
            .ForMember(usr => usr.Id, opt => opt.MapFrom(evnt => evnt.UserId));
    }
}