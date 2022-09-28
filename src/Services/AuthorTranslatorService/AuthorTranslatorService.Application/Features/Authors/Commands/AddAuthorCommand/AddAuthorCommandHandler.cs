using AuthorTranslatorService.Application.Abstraction.Persistence.Repositories.AuthorRepository;
using AuthorTranslatorService.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AuthorTranslatorService.Application.Features.Authors.Commands.AddAuthorCommand
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommandRequest, AddAuthorCommandResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AddAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AddAuthorCommandResponse> Handle(AddAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var authorToAdd = _mapper.Map<Author>(request);
            authorToAdd.Id = Guid.NewGuid();

            await _authorRepository.Add(authorToAdd);

            var response = _mapper.Map<AddAuthorCommandResponse>(authorToAdd);
            return response;
        }
    }
}
