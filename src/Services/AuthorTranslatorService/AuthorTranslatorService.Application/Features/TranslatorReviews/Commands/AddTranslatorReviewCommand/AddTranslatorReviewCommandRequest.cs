using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.Base;
using AuthorTranslatorService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand;
using MediatR;

namespace AuthorTranslatorService.Application.Features.TranslatorReviews.Commands.AddTranslatorReviewCommand
{
    public class AddTranslatorReviewCommandRequest : IRequest<AddTranslatorReviewCommandResponse>
    {
        public string Comment { get; set; }
        public double Rating { get; set; }
        public Guid TranslatorId { get; set; }
        public Guid UserId { get; set; }
    }
}
