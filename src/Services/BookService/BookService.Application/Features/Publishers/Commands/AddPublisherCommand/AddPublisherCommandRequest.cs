using MediatR;

namespace BookService.Application.Features.Publishers.Commands.AddPublisherCommand
{
    public class AddPublisherCommandRequest : IRequest<AddPublisherCommandResponse>
    {
        public string Name { get; set; }
    }
}
