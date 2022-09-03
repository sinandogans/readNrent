using AutoMapper;
using IdentityService.Application.Features.Users.Commands.UserRegisterCommand;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Mapping.AutoMapper
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<User, UserRegisterCommandResponse>().ReverseMap();
        }
    }
}
