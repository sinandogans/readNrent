using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Domain.Entities;
using BookService.Persistence.EntityFramework.Context;
using BookService.Persistence.EntityFramework.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace BookService.Persistence.EntityFramework.Repositories.GenreRepository
{
    public class EFGenreRepository : EFBaseRepository<Genre, BookServiceContext>, IGenreRepository
    {
        public async Task<List<Genre>> GetParentGenres(Guid genreId)
        {
            List<Genre> genres = new();

            using (BookServiceContext context = new())
            {
                var genre = await context.Set<Genre>().Include(g => g.Parent).SingleOrDefaultAsync(g => g.Id == genreId);
                genres.Add(genre);
                while (genre.ParentId != null)
                {
                    var parentGenre = genre.Parent;
                    genres.Add(parentGenre);
                    genre = await context.Set<Genre>().Include(g => g.Parent).SingleOrDefaultAsync(g => g.Id == parentGenre.Id);
                }
                return genres;
            }
        }
    }
}
