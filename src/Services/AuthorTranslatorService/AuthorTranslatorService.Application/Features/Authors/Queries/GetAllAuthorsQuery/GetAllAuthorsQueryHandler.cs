using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Queries.GetAllAuthorsQuery
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQueryRequest, List<GetAllAuthorsQueryResponse>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        async Task<List<GetAllAuthorsQueryResponse>> IRequestHandler<GetAllAuthorsQueryRequest, List<GetAllAuthorsQueryResponse>>.Handle(GetAllAuthorsQueryRequest request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetList();
            var response = _mapper.Map<List<GetAllAuthorsQueryResponse>>(authors);
            return response;
        }
    }
}
