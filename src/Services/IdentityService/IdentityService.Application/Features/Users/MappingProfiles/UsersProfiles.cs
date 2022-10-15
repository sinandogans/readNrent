using AutoMapper;
using IdentityService.Application.Features.Users.Commands.UserRegisterCommand;
using IdentityService.Application.IntegrationEvents.Users;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Features.Users.MappingProfiles
{
    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            CreateMap<User, UserRegisterCommandRequest>().ReverseMap();
            CreateMap<User, UserRegisteredIntegrationEvent>()
                .ForMember(evnt => evnt.UserId, opt => opt.MapFrom(u => u.Id))
                .ForMember(evnt => evnt.Id, opt => opt.Ignore());
        }
    }
}
