using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Application.Features.Authors.DTOs;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Queries.GetAllAuthorsQuery
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQueryRequest, GetAllAuthorsQueryResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        async Task<GetAllAuthorsQueryResponse> IRequestHandler<GetAllAuthorsQueryRequest, GetAllAuthorsQueryResponse>.Handle(GetAllAuthorsQueryRequest request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetList();
            GetAllAuthorRequestDTO authorsModel = new();
            authorsModel.Authors = authors;
            var response = _mapper.Map<GetAllAuthorsQueryResponse>(authorsModel);
            return response;
        }
    }
}
