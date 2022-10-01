using AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorReviewCommand;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;

namespace AuthorTranslatorService.Application.Mapping.AutoMapper
{
    public class TranslatorReviewsProfiles : Profile
    {
        public TranslatorReviewsProfiles()
        {
            CreateMap<TranslatorReview, AddTranslatorReviewCommandRequest>().ReverseMap();
            CreateMap<TranslatorReview, AddTranslatorReviewCommandResponse>().ReverseMap();
        }
    }
}
