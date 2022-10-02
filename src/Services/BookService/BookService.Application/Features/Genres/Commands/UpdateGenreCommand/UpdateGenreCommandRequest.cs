using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Application.Features.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Genres.Commands.UpdateGenreCommand
{
    public class UpdateGenreCommandRequest : IRequest<UpdateGenreCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommandRequest, UpdateGenreCommandResponse>
    {
        private readonly IGenreRepository _genreRepository;

        public UpdateGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<UpdateGenreCommandResponse> Handle(UpdateGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var genreToUpdate = await _genreRepository.GetById(request.Id);
            genreToUpdate.Name = request.Name;
            await _genreRepository.Update(genreToUpdate);

            return new UpdateGenreCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
    public class UpdateGenreCommandResponse : Response
    {
    }
}
