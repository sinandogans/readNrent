using AutoMapper;
using BookService.Application.Abstraction.Persistence.TranslatorRepository;
using BookService.Application.Abstraction.Persistence.TranslatorReviewRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.TranslatorReviews.Commands.AddTranslatorReviewCommand
{
    public class AddTranslatorReviewCommandHandler : IRequestHandler<AddTranslatorReviewCommandRequest, AddTranslatorReviewCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly ITranslatorReviewRepository _translatorReviewRepository;
        private readonly IMapper _mapper;

        public AddTranslatorReviewCommandHandler(ITranslatorRepository translatorRepository, IMapper mapper, ITranslatorReviewRepository translatorReviewRepository)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
            _translatorReviewRepository = translatorReviewRepository;
        }

        public async Task<AddTranslatorReviewCommandResponse> Handle(AddTranslatorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToAdd = _mapper.Map<TranslatorReview>(request);
            reviewToAdd.Id = Guid.NewGuid();
            reviewToAdd.Date = DateTime.Now;
            await _translatorReviewRepository.Add(reviewToAdd);

            var translator = await _translatorRepository.GetById(reviewToAdd.TranslatorId);
            translator.ReviewIds.Add(reviewToAdd.Id);
            translator.Feature.Rating = (translator.Feature.Rating * translator.Feature.ReviewCount + reviewToAdd.Rating) / (translator.Feature.ReviewCount + 1);
            translator.Feature.ReviewCount++;
            await _translatorRepository.Update(translator);

            return new AddTranslatorReviewCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
