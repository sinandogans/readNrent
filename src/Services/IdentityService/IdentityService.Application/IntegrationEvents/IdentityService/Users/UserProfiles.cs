using AutoMapper;
using IdentityService.Application.IntegrationEvents.IdentityService.Users.UserRegistered;
using IdentityService.Application.IntegrationEvents.IdentityService.Users.UserUpdated;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.IntegrationEvents.IdentityService.Users;

public class UserProfiles : Profile
{
    public UserProfiles()
    {
        CreateMap<User, UserRegisteredIntegrationEvent>()
            .ForMember(evnt => evnt.UserId, opt => opt.MapFrom(u => u.Id))
            .ForMember(evnt => evnt.Id, opt => opt.Ignore());

        CreateMap<User, UserUpdatedIntegrationEvent>()
            .ForMember(evnt => evnt.UserId, opt => opt.MapFrom(u => u.Id))
            .ForMember(evnt => evnt.Id, opt => opt.Ignore());
    }
}