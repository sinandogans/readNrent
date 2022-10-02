using AutoMapper;
using BookService.Application.Features.TranslatorReviews.Commands.AddTranslatorReviewCommand;
using BookService.Domain.Entities;

namespace BookService.Application.Features.TranslatorReviews.MappingProfiles
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
