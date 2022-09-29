using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Application.Features.Translators.DTOs;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Queries.GetAllTranslatorsQuery
{
    public class GetAllTranslatorsQueryHandler : IRequestHandler<GetAllTranslatorsQueryRequest, GetAllTranslatorsQueryResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;

        public GetAllTranslatorsQueryHandler(ITranslatorRepository translatorRepository, IMapper mapper)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
        }

        public async Task<GetAllTranslatorsQueryResponse> Handle(GetAllTranslatorsQueryRequest request, CancellationToken cancellationToken)
        {
            var translators = await _translatorRepository.GetList();
            var response = _mapper.Map<List<GetTranslatorDTO>>(translators);
            return new GetAllTranslatorsQueryResponse()
            {
                Message = "",
                Success = true,
                Data = response
            };
        }
    }
}
