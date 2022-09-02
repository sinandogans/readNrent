using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Abstraction.Persistence.GenreRepository;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookGenreCommand
{
    public class AddBookGenreCommandHandler : IRequestHandler<AddBookGenreCommandRequest, AddBookGenreCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IGenreReadRepository _genreReadRepository;
        private readonly IBookReadRepository _bookReadRepository;

        public AddBookGenreCommandHandler(IBookWriteRepository bookWriteRepository, IGenreReadRepository genreReadRepository, IBookReadRepository bookReadRepository)
        {
            _bookWriteRepository = bookWriteRepository;
            _genreReadRepository = genreReadRepository;
            _bookReadRepository = bookReadRepository;
        }

        public async Task<AddBookGenreCommandResponse> Handle(AddBookGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookReadRepository.Get(b => b.Id == request.BookId);
            var genres = await _genreReadRepository.GetParentGenres(request.GenreId);
            foreach (var genre in genres)
            {
                book.Genres.Add(genre);
                //await _bookWriteRepository.AddBookGenre(request.BookId, genre);
            }
            var updatedBook = await _bookWriteRepository.Update(book);

            return new AddBookGenreCommandResponse()
            {
                Id = updatedBook.Id,
                Genres = genres
            };
        }
    }
}
