using AutoMapper;
using BookService.Application.Features.Users.Commands.AddUserBookCommand;
using BookService.Domain.Entities;

namespace BookService.Application.Features.Users.MappingProfiles
{
    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            CreateMap<UserBook, AddUserBookCommandRequest>().ReverseMap();
        }
    }
}
