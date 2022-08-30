using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.AuthorReviews.Commands.AddAuthorReviewCommand
{
    public class AddAuthorReviewCommandHandler : IRequestHandler<AddAuthorReviewCommandRequest, AddAuthorReviewCommandResponse>
    {
        private readonly IAuthorReviewWriteRepository _repository;
        private readonly IMapper _mapper;
        public async Task<AddAuthorReviewCommandResponse> Handle(AddAuthorReviewCommandRequest request, CancellationToken cancellationToken)
        {
            //UserService'e UserId ile istek atıp firstname ve lastname i alıp burdaki propertye eklenecek ve veritabanında tutulacak.
            var reviewToAdd = _mapper.Map<AuthorReview>(request);
            await _repository.Add(reviewToAdd);

            var response = _mapper.Map<AddAuthorReviewCommandResponse>(reviewToAdd);
            return response;
        }
    }
}
