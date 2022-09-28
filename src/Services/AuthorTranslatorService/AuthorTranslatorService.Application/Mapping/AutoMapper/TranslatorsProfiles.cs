using AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorCommand;
using AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorReviewCommand;
using AuthorTranslatorService.Application.Features.Translators.Queries.GetAllTranslatorsQuery;
using AuthorTranslatorService.Application.Features.Translators.Queries.GetTranslatorByIdQuery;
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

            CreateMap<Translator, GetTranslatorByIdQueryResponse>().ReverseMap();
            CreateMap<Translator, GetTranslatorByIdQueryRequest>().ReverseMap();

            CreateMap<Translator, GetAllTranslatorsQueryResponse>().ReverseMap();
            CreateMap<Translator, GetAllTranslatorsQueryRequest>().ReverseMap();

            //

            CreateMap<TranslatorReview, AddTranslatorReviewCommandRequest>().ReverseMap();
            CreateMap<TranslatorReview, AddTranslatorReviewCommandResponse>().ReverseMap();
        }
    }
}
