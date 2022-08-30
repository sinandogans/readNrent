using AuthorTranslatorService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand;
using AuthorTranslatorService.Application.Features.AuthorReviews.Queries.GetAuthorReviewsByAuthorIdQuery;
using AuthorTranslatorService.Application.Features.AuthorReviews.Queries.GetAuthorReviewsByUserIdQuery;
using AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorCommand;
using AuthorTranslatorService.Application.Features.Authors.Queries.GetAllAuthorsQuery;
using AuthorTranslatorService.Application.Features.Authors.Queries.GetAuthorByIdQuery;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;

namespace AuthorTranslatorService.Application.Mapping.AutoMapper
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Author, AddAuthorCommandRequest>().ReverseMap();
            CreateMap<Author, AddAuthorCommandResponse>().ReverseMap();

            CreateMap<Author, GetAuthorByIdQueryResponse>().ReverseMap();

            CreateMap<Author, GetAllAuthorsQueryResponse>().ReverseMap();

            CreateMap<AuthorReview, AddAuthorReviewCommandRequest>().ReverseMap();
            CreateMap<AuthorReview, AddAuthorReviewCommandResponse>().ReverseMap();

            CreateMap<AuthorReview, GetAuthorReviewsByAuthorIdQueryResponse>().ReverseMap();

            CreateMap<AuthorReview, GetAuthorReviewsByUserIdQueryResponse>().ReverseMap();



        }
    }
}
