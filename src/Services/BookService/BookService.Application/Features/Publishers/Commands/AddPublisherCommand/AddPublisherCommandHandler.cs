using AutoMapper;
using BookService.Application.Abstraction.Persistence.PublisherRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Publishers.Commands.AddPublisherCommand
{
    public class AddPublisherCommandHandler : IRequestHandler<AddPublisherCommandRequest, AddPublisherCommandResponse>
    {
        private readonly IPublisherWriteRepository _publisherWriteRepository;
        private readonly IMapper _mapper;

        public AddPublisherCommandHandler(IPublisherWriteRepository publisherWriteRepository, IMapper mapper)
        {
            _publisherWriteRepository = publisherWriteRepository;
            _mapper = mapper;
        }

        public async Task<AddPublisherCommandResponse> Handle(AddPublisherCommandRequest request, CancellationToken cancellationToken)
        {
            var publisherToAdd = _mapper.Map<Publisher>(request);
            var addedPublisher = await _publisherWriteRepository.Add(publisherToAdd);
            return _mapper.Map<AddPublisherCommandResponse>(addedPublisher);
        }
    }
}
