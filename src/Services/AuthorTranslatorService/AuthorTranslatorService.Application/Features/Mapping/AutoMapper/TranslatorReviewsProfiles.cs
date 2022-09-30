using AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorReviewCommand;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorTranslatorService.Application.Mapping.AutoMapper
{
    public class TranslatorReviewsProfiles : Profile
    {
        public TranslatorReviewsProfiles()
        {
            CreateMap<TranslatorReview, AddTranslatorReviewCommandRequest>().ReverseMap();
            CreateMap<TranslatorReview, AddTranslatorReviewCommandResponse>().ReverseMap();
        }
    }
}
