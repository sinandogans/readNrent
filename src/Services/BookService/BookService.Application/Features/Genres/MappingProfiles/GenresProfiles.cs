using AutoMapper;
using BookService.Application.Features.Genres.Commands.AddGenreCommand;
using BookService.Domain.Entities;

namespace BookService.Application.Features.Genres.MappingProfiles
{
    public class GenresProfiles : Profile
    {
        public GenresProfiles()
        {
            CreateMap<Genre, AddGenreCommandRequest>().ReverseMap();
        }
    }
}
