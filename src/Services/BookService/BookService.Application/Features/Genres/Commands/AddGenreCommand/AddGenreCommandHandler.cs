using AutoMapper;
using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Genres.Commands.AddGenreCommand
{
    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommandRequest, AddGenreCommandResponse>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public AddGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<AddGenreCommandResponse> Handle(AddGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var genreToAdd = _mapper.Map<Genre>(request);
            genreToAdd.Id = Guid.NewGuid();
            await _genreRepository.Add(genreToAdd);

            return _mapper.Map<AddGenreCommandResponse>(genreToAdd);
        }
    }
}
