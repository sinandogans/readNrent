using AutoMapper;
using BookService.Application.Features.Translators.Commands.AddTranslatorCommand;
using BookService.Application.Features.Translators.DTOs;
using BookService.Domain.Entities;

namespace BookService.Application.Features.Mapping.AutoMapper
{
    public class TranslatorsProfiles : Profile
    {
        public TranslatorsProfiles()
        {
            CreateMap<Translator, AddTranslatorCommandRequest>().ReverseMap();
            CreateMap<Translator, AddTranslatorCommandResponse>().ReverseMap();

            CreateMap<Translator, GetTranslatorDTO>().ReverseMap();
        }
    }
}
