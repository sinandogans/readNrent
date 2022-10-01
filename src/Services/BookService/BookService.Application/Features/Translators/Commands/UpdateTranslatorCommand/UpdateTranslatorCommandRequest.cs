using MediatR;

namespace BookService.Application.Features.Translators.Commands.UpdateTranslatorCommand
{
    public class UpdateTranslatorCommandRequest : IRequest<UpdateTranslatorCommandResponse>
    {
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}
