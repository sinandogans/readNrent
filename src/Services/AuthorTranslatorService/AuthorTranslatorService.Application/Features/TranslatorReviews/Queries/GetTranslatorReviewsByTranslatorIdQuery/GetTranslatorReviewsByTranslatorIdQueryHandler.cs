using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorReviewRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.TranslatorReviews.Queries.GetTranslatorReviewsByTranslatorIdQuery
{
    public class GetTranslatorReviewsByTranslatorIdQueryHandler : IRequestHandler<GetTranslatorReviewsByTranslatorIdQueryRequest, List<GetTranslatorReviewsByTranslatorIdQueryResponse>>
    {
        private readonly ITranslatorReviewReadRepository _repository;
        private readonly IMapper _mapper;

        public GetTranslatorReviewsByTranslatorIdQueryHandler(ITranslatorReviewReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetTranslatorReviewsByTranslatorIdQueryResponse>> Handle(GetTranslatorReviewsByTranslatorIdQueryRequest request, CancellationToken cancellationToken)
        {
            var translatorReviews = await _repository.GetList(tr => tr.TranslatorId == request.TranslatorId);
            List<GetTranslatorReviewsByTranslatorIdQueryResponse> response = new();
            foreach (var translatorReview in translatorReviews)
            {
                response.Add(_mapper.Map<GetTranslatorReviewsByTranslatorIdQueryResponse>(translatorReview));
            }
            return response;
        }
    }
}
