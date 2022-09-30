using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorReviewCommand
{
    public class AddAuthorReviewCommandRequest : IRequest<AddAuthorReviewCommandResponse>
    {
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public Guid AuthorId { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
    }
}
