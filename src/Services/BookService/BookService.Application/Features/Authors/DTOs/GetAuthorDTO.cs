using BookService.Domain.Entities;

namespace BookService.Application.Features.Authors.DTOs
{
    public class GetAuthorDTO
    {
        public Guid Id { get; set; }
        public AuthorFeature Feature { get; set; }
        public List<Guid> ReviewIds { get; set; }
        public List<Guid> BookIds { get; set; }
    }
}
