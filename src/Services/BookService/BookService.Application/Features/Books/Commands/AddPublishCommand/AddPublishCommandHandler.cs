using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookPublishCommand
{
    public class AddPublishCommandHandler : IRequestHandler<AddPublishCommandRequest, AddPublishCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public AddPublishCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<AddPublishCommandResponse> Handle(AddPublishCommandRequest request, CancellationToken cancellationToken)
        {
            var publishtoAdd = _mapper.Map<Publish>(request);
            publishtoAdd.Id = Guid.NewGuid();

            await _bookRepository.AddPublish(publishtoAdd);
            var response = _mapper.Map<AddPublishCommandResponse>(publishtoAdd);
            return response;
        }
    }
}
