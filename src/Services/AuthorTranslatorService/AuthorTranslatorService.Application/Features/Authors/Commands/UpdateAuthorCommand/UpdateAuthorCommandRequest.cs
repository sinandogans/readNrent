using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.UpdateAuthorCommand
{
    public class UpdateAuthorCommandRequest : IRequest<UpdateAuthorCommandResponse>
    {
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}
