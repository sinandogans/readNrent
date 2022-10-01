using MediatR;

namespace BookService.Application.Features.Translators.Commands.DeleteTranslatorCommand
{
    public class DeleteTranslatorCommandRequest : IRequest<DeleteTranslatorCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
