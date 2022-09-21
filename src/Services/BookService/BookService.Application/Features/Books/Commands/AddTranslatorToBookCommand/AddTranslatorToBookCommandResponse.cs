using BookService.Domain.Entities;

namespace BookService.Application.Features.Books.Commands.AddTranslatorToBookCommand
{
    public class AddTranslatorToBookCommandResponse
    {
        public Guid Id { get; set; }
        public List<TranslatorModel> Translators { get; set; }
    }
}
