using AutoMapper;
using ReviewService.Application.Features.BookReviews.Commands.AddBookReviewCommand;
using ReviewService.Domain.Entities;

namespace ReviewService.Application.Features.BookReviews.MappingProfiles
{
    public class BookReviewsProfiles : Profile
    {
        public BookReviewsProfiles()
        {
            CreateMap<BookReview, AddBookReviewCommandRequest>().ReverseMap();
            CreateMap<BookReview, AddBookReviewCommandResponse>().ReverseMap();
        }
    }
}
