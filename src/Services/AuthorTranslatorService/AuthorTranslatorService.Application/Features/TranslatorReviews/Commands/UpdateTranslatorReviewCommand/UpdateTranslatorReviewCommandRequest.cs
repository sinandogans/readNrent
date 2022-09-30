using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.UpdateAuthorReviewCommand
{
    public class UpdateTranslatorReviewCommandRequest : IRequest<UpdateTranslatorReviewCommandResponse>
    {
        public Guid Id { get; set; }
        public string? Comment { get; set; }
        public double? Rating { get; set; }
    }
}
