using AutoMapper;
using IdentityService.Application.Features.Users.Commands.UserRegisterCommand;
using IdentityService.Application.IntegrationEvents.IdentityService.Users.UserRegistered;
using IdentityService.Application.IntegrationEvents.IdentityService.Users.UserUpdated;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Features.Users.MappingProfiles
{
    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            CreateMap<User, UserRegisterCommandRequest>().ReverseMap();
        }
    }
}
