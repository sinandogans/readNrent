using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Queries.GetAllAuthorsQuery
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQueryRequest, List<GetAllAuthorsQueryResponse>>
    {
        private readonly IAuthorReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAuthorsQueryHandler(IAuthorReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<List<GetAllAuthorsQueryResponse>> IRequestHandler<GetAllAuthorsQueryRequest, List<GetAllAuthorsQueryResponse>>.Handle(GetAllAuthorsQueryRequest request, CancellationToken cancellationToken)
        {
            var authors = await _repository.GetList();
            List<GetAllAuthorsQueryResponse> response = new();
            foreach (var author in authors)
            {
                response.Add(_mapper.Map<GetAllAuthorsQueryResponse>(author));
            }
            return response;
        }
    }
}
