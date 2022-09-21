using MediatR;

namespace BookService.Application.Features.Books.Commands.AddTranslatorToBookCommand
{
    public class AddTranslatorToBookCommandRequest : IRequest<AddTranslatorToBookCommandResponse>
    {
        public Guid BookId { get; set; }
        public Guid TranslatorId { get; set; }
    }
}
