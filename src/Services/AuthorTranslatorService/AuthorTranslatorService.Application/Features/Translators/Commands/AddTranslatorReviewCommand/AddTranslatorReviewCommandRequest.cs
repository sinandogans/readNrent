using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorReviewCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorTranslatorService.Application.Features.Translators.Commands.AddTranslatorReviewCommand
{
    public class AddTranslatorReviewCommandRequest : IRequest<AddTranslatorReviewCommandResponse>
    {
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public Guid TranslatorId { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
    }
}
