using MediatR;

namespace BookService.Application.Features.Translators.Commands.AddTranslatorCommand
{
    public class AddTranslatorCommandRequest : IRequest<AddTranslatorCommandResponse>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
