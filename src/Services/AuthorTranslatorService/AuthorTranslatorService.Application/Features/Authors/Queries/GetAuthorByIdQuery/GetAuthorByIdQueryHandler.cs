using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Queries.GetAuthorByIdQuery
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQueryRequest, GetAuthorByIdQueryResponse>
    {
        private readonly IAuthorReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IAuthorReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAuthorByIdQueryResponse> Handle(GetAuthorByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var author = await _repository.Get(a => a.Id == request.Id);
            var response = _mapper.Map<GetAuthorByIdQueryResponse>(author);

            return response;
        }
    }
}
