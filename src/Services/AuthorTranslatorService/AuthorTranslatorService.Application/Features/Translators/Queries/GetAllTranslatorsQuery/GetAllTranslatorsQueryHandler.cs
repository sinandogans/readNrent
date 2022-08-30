using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Queries.GetAllTranslatorsQuery
{
    public class GetAllTranslatorsQueryHandler : IRequestHandler<GetAllTranslatorsQueryRequest, List<GetAllTranslatorsQueryResponse>>
    {
        private readonly ITranslatorReadRepository _repository;
        private readonly IMapper _mapper;

        public GetAllTranslatorsQueryHandler(ITranslatorReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllTranslatorsQueryResponse>> Handle(GetAllTranslatorsQueryRequest request, CancellationToken cancellationToken)
        {
            var translators = await _repository.GetList();
            List<GetAllTranslatorsQueryResponse> response = new();
            foreach (var translator in translators)
            {
                response.Add(_mapper.Map<GetAllTranslatorsQueryResponse>(translator));
            }
            return response;
        }
    }
}
