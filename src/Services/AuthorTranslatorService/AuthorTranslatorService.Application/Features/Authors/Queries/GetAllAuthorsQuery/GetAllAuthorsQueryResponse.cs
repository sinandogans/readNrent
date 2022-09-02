using AuthorTranslatorService.Application.Features.Authors.DTOs;

namespace AuthorTranslatorService.Application.Features.Authors.Queries.GetAllAuthorsQuery
{
    public class GetAllAuthorsQueryResponse
    {
        public List<GetAllAuthorsDTO> Authors { get; set; }
    }
}
