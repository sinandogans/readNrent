using AutoMapper;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Abstraction.Persistence.GenreRepository;
using MediatR;

namespace BookService.Application.Features.Books.Commands.AddBookGenreCommand
{
    public class AddGenreToBookCommandHandler : IRequestHandler<AddGenreToBookCommandRequest, AddGenreToBookCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public AddGenreToBookCommandHandler(IBookRepository bookRepository, IGenreRepository genreRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<AddGenreToBookCommandResponse> Handle(AddGenreToBookCommandRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.Get(b => b.Id == request.BookId);
            var genres = await _genreRepository.GetParentGenres(request.GenreId);
            foreach (var genre in genres)
            {
                book.Genres.Add(genre);
            }
            var updatedBook = await _bookRepository.Update(book);
            var response = _mapper.Map<AddGenreToBookCommandResponse>(updatedBook);

            return response;
        }
    }
}
