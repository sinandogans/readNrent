using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.DeleteAuthorCommand
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest, DeleteAuthorCommandResponse>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<DeleteAuthorCommandResponse> Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetById(request.Id);
            await _authorRepository.DeleteReviews(author.ReviewIds);

            await _authorRepository.Delete(request.Id);
            return new DeleteAuthorCommandResponse();
        }
    }
}
