using AutoMapper;
using BookService.Application.Abstraction.Persistence.AuthorRepository;
using MediatR;

namespace BookService.Application.Features.Authors.Commands.UpdateAuthorCommand
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, UpdateAuthorCommandResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<UpdateAuthorCommandResponse> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var authorToUpdate = await _authorRepository.GetById(request.Id);
            if (request.Firstname != null)
                authorToUpdate.Feature.Firstname = request.Firstname;
            if (request.Lastname != null)
                authorToUpdate.Feature.Lastname = request.Lastname;

            await _authorRepository.Update(authorToUpdate);
            return new UpdateAuthorCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
}
