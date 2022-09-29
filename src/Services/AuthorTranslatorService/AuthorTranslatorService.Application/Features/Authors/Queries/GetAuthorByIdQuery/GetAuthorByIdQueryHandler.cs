using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Application.Features.Authors.DTOs;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Queries.GetAuthorByIdQuery
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQueryRequest, GetAuthorByIdQueryResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<GetAuthorByIdQueryResponse> Handle(GetAuthorByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.Get(a => a.Id == request.Id);
            var response = _mapper.Map<GetAuthorDTO>(author);

            return new GetAuthorByIdQueryResponse()
            {
                Message = "",
                Success = true,
                Data = response
            };
        }
    }
}
