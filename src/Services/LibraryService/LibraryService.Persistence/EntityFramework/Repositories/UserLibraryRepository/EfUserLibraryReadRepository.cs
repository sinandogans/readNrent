using LibraryService.Application.Abstraction.Persistence.UserBookRepository;
using LibraryService.Domain.Entities;
using LibraryService.Persistence.EntityFramework.Contexts;
using LibraryService.Persistence.EntityFramework.Repositories.BaseRepository;

namespace LibraryService.Persistence.EntityFramework.Repositories.UserBookRepository
{
    public class EfUserLibraryReadRepository : EfBaseReadRepository<UserLibrary, LibraryServiceContext>, IUserLibraryReadRepository
    {
    }
}
