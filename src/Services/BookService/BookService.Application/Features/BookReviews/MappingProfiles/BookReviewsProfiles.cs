using AutoMapper;
using BookService.Application.Features.BookReviews.Commands.AddBookReviewCommand;
using BookService.Domain.AggregatesModel.BookAggregate;

namespace BookService.Application.Features.BookReviews.MappingProfiles
{
    public class BookReviewsProfiles : Profile
    {
        public BookReviewsProfiles()
        {
            CreateMap<BookReview, AddBookReviewCommandRequest>().ReverseMap();
        }
    }
}
