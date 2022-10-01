using AutoMapper;
using BookService.Application.Features.TranslatorReviews.Commands.AddTranslatorReviewCommand;
using BookService.Domain.Entities;

namespace BookService.Application.Features.Mapping.AutoMapper
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
