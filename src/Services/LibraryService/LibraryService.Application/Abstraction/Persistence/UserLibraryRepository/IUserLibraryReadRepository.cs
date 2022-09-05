using LibraryService.Application.Abstraction.Persistence.BaseRepository;
using LibraryService.Domain.Entities;

namespace LibraryService.Application.Abstraction.Persistence.UserBookRepository
{
    public interface IUserLibraryReadRepository : IBaseReadRepository<UserLibrary>
    {
    }
}
