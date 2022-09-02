using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Application.Features.Authors.DTOs;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Queries.GetAllAuthorsQuery
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQueryRequest, GetAllAuthorsQueryResponse>
    {
        private readonly IAuthorReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAuthorsQueryHandler(IAuthorReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<GetAllAuthorsQueryResponse> IRequestHandler<GetAllAuthorsQueryRequest, GetAllAuthorsQueryResponse>.Handle(GetAllAuthorsQueryRequest request, CancellationToken cancellationToken)
        {
            var authors = await _repository.GetList();
            GetAllAuthorRequestDTO authorsModel = new();
            authorsModel.Authors = authors;
            var response = _mapper.Map<GetAllAuthorsQueryResponse>(authorsModel);
            return response;
        }
    }
}
