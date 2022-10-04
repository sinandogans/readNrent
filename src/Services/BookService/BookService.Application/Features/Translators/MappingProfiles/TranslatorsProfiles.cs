using AutoMapper;
using BookService.Application.Features.Translators.Commands.AddTranslatorCommand;
using BookService.Application.Features.Translators.DTOs;
using BookService.Domain.Entities;

namespace BookService.Application.Features.Translators.MappingProfiles
{
    public class TranslatorsProfiles : Profile
    {
        public TranslatorsProfiles()
        {
            CreateMap<TranslatorFeature, AddTranslatorCommandRequest>().ReverseMap();

            CreateMap<Translator, GetTranslatorDTO>().ReverseMap();
        }
    }
}
