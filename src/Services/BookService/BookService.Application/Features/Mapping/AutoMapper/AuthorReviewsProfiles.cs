using AutoMapper;
using BookService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand;
using BookService.Domain.Entities;

namespace BookService.Application.Features.Mapping.AutoMapper
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
