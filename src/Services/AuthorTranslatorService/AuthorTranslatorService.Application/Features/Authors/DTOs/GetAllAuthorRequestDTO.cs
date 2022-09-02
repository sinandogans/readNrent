using AuthorTranslatorService.Domain.Entities;

namespace AuthorTranslatorService.Application.Features.Authors.DTOs
{
    public class GetAllAuthorRequestDTO
    {
        public List<Author> Authors { get; set; }
    }
}
