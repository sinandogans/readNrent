using AuthorTranslatorService.Domain.Entities;

namespace AuthorTranslatorService.Application.Features.Authors.Queries.GetAuthorByIdQuery
{
    public class GetAuthorByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<AuthorReview> Reviews { get; set; }
    }
}
