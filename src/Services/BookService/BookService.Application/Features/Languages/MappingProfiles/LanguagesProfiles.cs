using AutoMapper;
using BookService.Application.Features.Languages.Commands.AddLanguageCommand;
using BookService.Domain.Entities;

namespace BookService.Application.Features.Languages.MappingProfiles
{
    public class LanguagesProfiles : Profile
    {
        public LanguagesProfiles()
        {
            CreateMap<Language, AddLanguageCommandRequest>().ReverseMap();
        }
    }
}
