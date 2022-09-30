using AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorReviewCommand;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
