using MediatR;

namespace BookService.Application.Features.Languages.Commands.AddLanguageCommand
{
    public class AddLanguageCommandRequest : IRequest<AddLanguageCommandResponse>
    {
        public string Name { get; set; }
    }
}
