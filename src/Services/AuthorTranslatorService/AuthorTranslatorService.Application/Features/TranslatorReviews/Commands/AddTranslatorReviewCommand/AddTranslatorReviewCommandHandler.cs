using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.TranslatorReviewRepository;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.TranslatorReviews.Commands.AddTranslatorReviewCommand
{
    public class AddTranslatorReviewCommandHandler : IRequestHandler<AddTranslatorReviewCommandRequest, AddTranslatorReviewCommandResponse>
    {
        private readonly ITranslatorReviewWriteRepository _writeRepository;
        private readonly ITranslatorReviewReadRepository _readRepository;
        private readonly ITranslatorWriteRepository _translatorwWriteRepository;
        private readonly ITranslatorReadRepository _translatorReadRepository;
        private readonly IMapper _mapper;
        public AddTranslatorReviewCommandHandler(ITranslatorReviewWriteRepository writeRepository, ITranslatorReviewReadRepository readRepository, ITranslatorWriteRepository translatorwWriteRepository, ITranslatorReadRepository translatorReadRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _translatorwWriteRepository = translatorwWriteRepository;
            _translatorReadRepository = translatorReadRepository;
            _mapper = mapper;
        }

        public async Task<AddTranslatorReviewCommandResponse> Handle(AddTranslatorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            //UserService'e UserId ile istek atıp firstname ve lastname'i alıp burdaki propertye eklenecek ve veritabanında tutulacak.
            string? username = null;
            var userReview = await _readRepository.Get(r => r.UserId == request.UserId);
            if (userReview == null)
            {
                // UserService'e istek at getir.
            }
            else
            {
                username = userReview.Username;
            }

            var reviewToAdd = _mapper.Map<TranslatorReview>(request);
            reviewToAdd.Username = username;
            await _writeRepository.Add(reviewToAdd);

            var author = await _translatorReadRepository.Get(a => a.Id == reviewToAdd.TranslatorId);
            var ratingMultCount = author.Rating * author.ReviewCount;
            author.ReviewCount += 1;
            author.Rating = (ratingMultCount + reviewToAdd.Rating) / author.ReviewCount;
            await _translatorwWriteRepository.Update(author);

            var response = _mapper.Map<AddTranslatorReviewCommandResponse>(reviewToAdd);
            return response;
        }
    }
}
