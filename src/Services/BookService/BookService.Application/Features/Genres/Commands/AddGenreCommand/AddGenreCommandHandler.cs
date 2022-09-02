using AutoMapper;
using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Domain.Entities;
using MediatR;

namespace BookService.Application.Features.Genres.Commands.AddGenreCommand
{
    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommandRequest, AddGenreCommandResponse>
    {
        private readonly IGenreWriteRepository _genreWriteRepository;
        private readonly IMapper _mapper;

        public AddGenreCommandHandler(IGenreWriteRepository genreWriteRepository, IMapper mapper)
        {
            _genreWriteRepository = genreWriteRepository;
            _mapper = mapper;
        }

        public async Task<AddGenreCommandResponse> Handle(AddGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var genreToAdd = _mapper.Map<Genre>(request);
            genreToAdd.Id = Guid.NewGuid();
            var addedGenre = await _genreWriteRepository.Add(genreToAdd);

            return _mapper.Map<AddGenreCommandResponse>(addedGenre);
        }
    }
}
