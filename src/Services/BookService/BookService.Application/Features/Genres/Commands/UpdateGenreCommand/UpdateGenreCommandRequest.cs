using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Application.Utilities.ResponseModel;
using MediatR;

namespace BookService.Application.Features.Genres.Commands.UpdateGenreCommand
{
    public class UpdateGenreCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommandRequest, IResponseModel>
    {
        private readonly IGenreRepository _genreRepository;

        public UpdateGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IResponseModel> Handle(UpdateGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var genreToUpdate = await _genreRepository.GetById(request.Id);
            genreToUpdate.Name = request.Name;
            await _genreRepository.Update(genreToUpdate);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
