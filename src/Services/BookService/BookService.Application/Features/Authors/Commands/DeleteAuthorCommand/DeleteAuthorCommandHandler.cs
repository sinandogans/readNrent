using BookService.Application.Abstraction.Persistence.AuthorRepository;
using BookService.Application.Abstraction.Persistence.AuthorReviewRepository;
using MediatR;

namespace BookService.Application.Features.Authors.Commands.DeleteAuthorCommand
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
            await _authorReviewRepository.DeleteList(author.ReviewIds.ToList());

            await _authorRepository.Delete(request.Id);
            return new DeleteAuthorCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
