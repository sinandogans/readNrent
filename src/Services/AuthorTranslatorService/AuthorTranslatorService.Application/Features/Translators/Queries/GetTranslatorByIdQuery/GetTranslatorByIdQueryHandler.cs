using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Queries.GetTranslatorByIdQuery
{
    public class GetTranslatorByIdQueryHandler : IRequestHandler<GetTranslatorByIdQueryRequest, GetTranslatorByIdQueryResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;

        public GetTranslatorByIdQueryHandler(ITranslatorRepository translatorRepository, IMapper mapper)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
        }

        public async Task<GetTranslatorByIdQueryResponse> Handle(GetTranslatorByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var translator = await _translatorRepository.Get(t => t.Id == request.id);
            var response = _mapper.Map<GetTranslatorByIdQueryResponse>(translator);
            return response;
        }
    }
}
