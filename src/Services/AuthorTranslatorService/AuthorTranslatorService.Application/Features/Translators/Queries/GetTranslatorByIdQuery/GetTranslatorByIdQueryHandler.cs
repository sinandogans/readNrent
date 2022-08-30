using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Queries.GetTranslatorByIdQuery
{
    public class GetTranslatorByIdQueryHandler : IRequestHandler<GetTranslatorByIdQueryRequest, GetTranslatorByIdQueryResponse>
    {
        private readonly ITranslatorReadRepository _repository;
        private readonly IMapper _mapper;

        public GetTranslatorByIdQueryHandler(ITranslatorReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetTranslatorByIdQueryResponse> Handle(GetTranslatorByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var translator = await _repository.Get(t => t.Id == request.id);
            var response = _mapper.Map<GetTranslatorByIdQueryResponse>(translator);
            return response;
        }
    }
}
