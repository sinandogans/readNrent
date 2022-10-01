using AutoMapper;
using BookService.Application.Features.Authors.Commands.AddAuthorCommand;
using BookService.Domain.Entities;

namespace BookService.Application.Features.Mapping.AutoMapper
{
    public class AuthorsProfiles : Profile
    {
        public AuthorsProfiles()
        {
            CreateMap<Author, AddAuthorCommandRequest>().ReverseMap();
            CreateMap<Author, AddAuthorCommandResponse>().ReverseMap();

            CreateMap<Author, UpdateAuthorCommandResponse>().ReverseMap();

            CreateMap<Author, GetAuthorDTO>().ReverseMap();
            //

        }
    }
}
