using AutoMapper;
using BookService.Application.Features.Authors.Commands.AddAuthorCommand;
using BookService.Application.Features.Authors.DTOs;
using BookService.Domain.AggregatesModel.AuthorAggregate;

namespace BookService.Application.Features.Authors.MappingProfiles
{
    public class AuthorsProfiles : Profile
    {
        public AuthorsProfiles()
        {
            CreateMap<Author, AddAuthorCommandRequest>().ReverseMap();
            CreateMap<Author, GetAuthorDTO>().ReverseMap();
            //

        }
    }
}
