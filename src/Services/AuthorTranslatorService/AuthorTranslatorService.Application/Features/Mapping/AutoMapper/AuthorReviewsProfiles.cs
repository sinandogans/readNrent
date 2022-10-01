using AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorReviewCommand;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;

namespace AuthorTranslatorService.Application.Mapping.AutoMapper
{
    public class AuthorReviewsProfiles : Profile
    {
        public AuthorReviewsProfiles()
        {
            CreateMap<AuthorReview, AddAuthorReviewCommandRequest>().ReverseMap();
            CreateMap<AuthorReview, AddAuthorReviewCommandResponse>().ReverseMap();
        }
    }
}
