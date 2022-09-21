using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookReviewCommand
{
    public class AddBookReviewCommandHandler : IRequestHandler<AddBookReviewCommandRequest, AddBookReviewCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddBookReviewCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<AddBookReviewCommandResponse> Handle(AddBookReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var reviewToAdd = _mapper.Map<BookReview>(request);
            reviewToAdd.Id = Guid.NewGuid();

            await _bookRepository.AddBookReview(reviewToAdd);

            var response = _mapper.Map<AddBookReviewCommandResponse>(reviewToAdd);
            return response;
        }
    }
}
