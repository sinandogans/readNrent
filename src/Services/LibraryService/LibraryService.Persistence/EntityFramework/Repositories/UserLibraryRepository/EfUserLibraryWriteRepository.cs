using LibraryService.Application.Abstraction.Persistence.UserBookRepository;
using LibraryService.Domain.Entities;
using LibraryService.Persistence.EntityFramework.Contexts;
using LibraryService.Persistence.EntityFramework.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Persistence.EntityFramework.Repositories.UserBookRepository
{
    public class EfUserLibraryWriteRepository : EfBaseWriteRepository<UserLibrary, LibraryServiceContext>, IUserLibraryWriteRepository
    {
        public async Task AddLibraryBook(Guid userId, LibraryBook libraryBook)
        {
            using (LibraryServiceContext context = new LibraryServiceContext())
            {
                var userLibrary = await context.Set<UserLibrary>().SingleOrDefaultAsync(u => u.UserId == userId);
                await context.Set<LibraryBook>().AddAsync(libraryBook);

                userLibrary.LibraryBooks.Add(libraryBook);
                await context.SaveChangesAsync();
            }
        }
    }
}
