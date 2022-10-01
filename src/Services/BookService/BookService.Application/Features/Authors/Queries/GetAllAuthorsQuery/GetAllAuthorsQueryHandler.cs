using AutoMapper;
using BookService.Application.Abstraction.Persistence.AuthorRepository;
using BookService.Application.Features.Authors.DTOs;
using MediatR;

namespace BookService.Application.Features.Authors.Queries.GetAllAuthorsQuery
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
            var response = _mapper.Map<List<GetAuthorDTO>>(authors);

            return new GetAllAuthorsQueryResponse()
            {
                Message = "",
                Success = true,
                Data = response
            };
        }
    }
}
