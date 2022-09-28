using AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorCommand;
using AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorReviewCommand;
using AuthorTranslatorService.Application.Features.Authors.Commands.UpdateAuthorCommand;
using AuthorTranslatorService.Application.Features.Authors.Queries.GetAllAuthorsQuery;
using AuthorTranslatorService.Application.Features.Authors.Queries.GetAuthorByIdQuery;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;

namespace AuthorTranslatorService.Application.Mapping.AutoMapper
{
    public class AuthorsProfiles : Profile
    {
        public AuthorsProfiles()
        {
            CreateMap<Author, AddAuthorCommandRequest>().ReverseMap();
            CreateMap<Author, AddAuthorCommandResponse>().ReverseMap();

            CreateMap<Author, GetAuthorByIdQueryResponse>().ReverseMap();
            CreateMap<Author, GetAuthorByIdQueryRequest>().ReverseMap();

            CreateMap<Author, GetAllAuthorsQueryResponse>().ReverseMap();
            CreateMap<Author, GetAllAuthorsQueryRequest>().ReverseMap();

            CreateMap<Author, UpdateAuthorCommandResponse>().ReverseMap();


            //

            CreateMap<AuthorReview, AddAuthorReviewCommandRequest>().ReverseMap();
            CreateMap<AuthorReview, AddAuthorReviewCommandResponse>().ReverseMap();
        }
    }
}
