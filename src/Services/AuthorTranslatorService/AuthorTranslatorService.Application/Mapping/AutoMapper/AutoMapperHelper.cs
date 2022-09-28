using AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorCommand;
using AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorReviewCommand;
using AuthorTranslatorService.Application.Features.Authors.Queries.GetAllAuthorsQuery;
using AuthorTranslatorService.Application.Features.Authors.Queries.GetAuthorByIdQuery;
using AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorCommand;
using AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorReviewCommand;
using AuthorTranslatorService.Application.Features.Translators.Queries.GetAllTranslatorsQuery;
using AuthorTranslatorService.Application.Features.Translators.Queries.GetTranslatorByIdQuery;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;

namespace AuthorTranslatorService.Application.Mapping.AutoMapper
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Translator, GetTranslatorByIdQueryResponse>().ReverseMap();
            CreateMap<Translator, GetAllTranslatorsQueryResponse>().ReverseMap();

            //AUTHOR BEGİN
            CreateMap<Author, AddAuthorCommandRequest>().ReverseMap();
            CreateMap<Author, AddAuthorCommandResponse>().ReverseMap();

            CreateMap<Author, GetAuthorByIdQueryResponse>().ReverseMap();
            CreateMap<Author, GetAuthorByIdQueryRequest>().ReverseMap();

            CreateMap<Author, GetAllAuthorsQueryResponse>().ReverseMap();
            CreateMap<Author, GetAllAuthorsQueryRequest>().ReverseMap();

            //AUTHOR END

            //AUTHOR REVİEW BEGİN
            CreateMap<AuthorReview, AddAuthorReviewCommandRequest>().ReverseMap();
            CreateMap<AuthorReview, AddAuthorReviewCommandResponse>().ReverseMap();
            //AUTHOR REVİEW END

            //TRANSLATOR BEGİN
            CreateMap<Translator, AddTranslatorCommandRequest>().ReverseMap();
            CreateMap<Translator, AddTranslatorCommandResponse>().ReverseMap();
            //TRANSLATOR END

            //TRANSLATOR REVİEW BEGİN
            CreateMap<TranslatorReview, AddTranslatorReviewCommandRequest>().ReverseMap();
            CreateMap<TranslatorReview, AddTranslatorReviewCommandResponse>().ReverseMap();
            //TRANSLATOR REVİEW END
        }
    }
}
