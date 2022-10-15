using AutoMapper;
using BookService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand;
using BookService.Domain.Entities;

namespace BookService.Application.Features.AuthorReviews.MappingProfiles
{
    public class AuthorReviewsProfiles : Profile
    {
        public AuthorReviewsProfiles()
        {
            CreateMap<AuthorReview, AddAuthorReviewCommandRequest>().ReverseMap();
        }
    }
}
