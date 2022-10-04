using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Genres.Commands.DeleteGenreCommand
{
    public class DeleteGenreCommandRequest : IRequest<DeleteGenreCommandResponse>
    {
        public Guid Id { get; set; }
    }
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommandRequest, DeleteGenreCommandResponse>
    {
        private readonly IGenreRepository _genreRepository;

        public DeleteGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<DeleteGenreCommandResponse> Handle(DeleteGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var parentGenre = await _genreRepository.GetBySubGenreId(request.Id);
            parentGenre.SubGenreIds.Remove(request.Id);
            var subGenres = await _genreRepository.GetSubGenres(request.Id);

            await _genreRepository.Update(parentGenre);
            await _genreRepository.Delete(request.Id);
            foreach (var subGenre in subGenres)
            {
                await _genreRepository.Delete(subGenre.Id);
            }

            return new DeleteGenreCommandResponse()
            {
                Message = "",
                Success = true
            };
        }
    }
    public class DeleteGenreCommandResponse : Response
    {
    }
}
