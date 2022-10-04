using AutoMapper;
using BookService.Application.Features.Authors.Commands.AddAuthorCommand;
using BookService.Application.Features.Authors.Commands.UpdateAuthorCommand;
using BookService.Application.Features.Authors.DTOs;
using BookService.Domain.Entities;

namespace BookService.Application.Features.Authors.MappingProfiles
{
    public class AuthorsProfiles : Profile
    {
        public AuthorsProfiles()
        {
            CreateMap<AuthorFeature, AddAuthorCommandRequest>().ReverseMap();
            CreateMap<Author, AddAuthorCommandResponse>().ReverseMap();

            CreateMap<Author, UpdateAuthorCommandResponse>().ReverseMap();

            CreateMap<Author, GetAuthorDTO>().ReverseMap();
            //

        }
    }
}
