using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Translators.Commands.DeleteTranslatorReviewCommand
{
    public class DeleteTranslatorReviewCommandHandler : IRequestHandler<DeleteTranslatorReviewCommandRequest, DeleteTranslatorReviewCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;

        public DeleteTranslatorReviewCommandHandler(ITranslatorRepository translatorRepository, IMapper mapper)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
        }

        public async Task<DeleteTranslatorReviewCommandResponse> Handle(DeleteTranslatorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            await _translatorRepository.DeleteReview(request.Id);
            return new DeleteTranslatorReviewCommandResponse();
        }
    }
}
