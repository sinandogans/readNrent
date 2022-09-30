using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorReviewRepository;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest, DeleteAuthorCommandResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorReviewRepository _authorReviewRepository;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IAuthorReviewRepository authorReviewRepository)
        {
            _authorRepository = authorRepository;
            _authorReviewRepository = authorReviewRepository;
        }

        public async Task<DeleteAuthorCommandResponse> Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetById(request.Id);
            await _authorReviewRepository.DeleteList(author.ReviewIds);

            await _authorRepository.Delete(request.Id);
            return new DeleteAuthorCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
