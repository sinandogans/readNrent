using BookService.Domain.Entities;

namespace BookService.Application.Features.Translators.DTOs
{
    public class GetTranslatorDTO
    {
        public Guid Id { get; set; }
        public TranslatorFeature Feature { get; set; }
        public List<Guid> ReviewIds { get; set; }
        public List<Guid> BookIds { get; set; }
    }
}
