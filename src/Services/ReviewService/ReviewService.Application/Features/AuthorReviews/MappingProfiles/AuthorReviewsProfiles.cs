using AutoMapper;
using ReviewService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand;
using ReviewService.Domain.Entities;

namespace ReviewService.Application.Features.AuthorReviews.MappingProfiles
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
