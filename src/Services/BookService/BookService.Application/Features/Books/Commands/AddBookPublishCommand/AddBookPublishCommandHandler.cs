using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookPublishCommand
{
    public class AddBookPublishCommandHandler : IRequestHandler<AddBookPublishCommandRequest, AddBookPublishCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IMapper _mapper;

        public AddBookPublishCommandHandler(IBookWriteRepository bookWriteRepository, IMapper mapper)
        {
            _bookWriteRepository = bookWriteRepository;
            _mapper = mapper;
        }

        public async Task<AddBookPublishCommandResponse> Handle(AddBookPublishCommandRequest request, CancellationToken cancellationToken)
        {
            var publish = _mapper.Map<Publish>(request);
            publish.Id = Guid.NewGuid();
            publish.PublishDate = DateTime.Now;

            await _bookWriteRepository.AddBookPublish(publish);
            return _mapper.Map<AddBookPublishCommandResponse>(publish);
        }
    }
}
