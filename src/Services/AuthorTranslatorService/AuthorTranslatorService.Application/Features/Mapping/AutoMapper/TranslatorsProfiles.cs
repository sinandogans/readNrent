using AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorCommand;
using AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorReviewCommand;
using AuthorTranslatorService.Application.Features.Translators.DTOs;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;

namespace AuthorTranslatorService.Application.Mapping.AutoMapper
{
    public class TranslatorsProfiles : Profile
    {
        public TranslatorsProfiles()
        {
            CreateMap<Translator, AddTranslatorCommandRequest>().ReverseMap();
            CreateMap<Translator, AddTranslatorCommandResponse>().ReverseMap();

            CreateMap<Translator, GetTranslatorDTO>().ReverseMap();

            //


        }
    }
}
