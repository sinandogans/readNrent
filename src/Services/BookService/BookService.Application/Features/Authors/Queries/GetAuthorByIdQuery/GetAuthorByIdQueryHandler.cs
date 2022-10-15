using AutoMapper;
using BookService.Application.Abstraction.Persistence.AuthorRepository;
using BookService.Application.Features.Authors.DTOs;
using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Authors.Queries.GetAuthorByIdQuery
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQueryRequest, IDataResponseModel<GetAuthorDTO>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IDataResponseModel<GetAuthorDTO>> Handle(GetAuthorByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.Get(a => a.Id == request.Id);
            var response = _mapper.Map<GetAuthorDTO>(author);

            return new SuccessDataResponseModel<GetAuthorDTO>()
            {
                Message = "",
                Data = response
            };
        }
    }
}
