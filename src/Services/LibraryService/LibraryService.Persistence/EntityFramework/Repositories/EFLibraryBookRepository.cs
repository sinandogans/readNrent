using LibraryService.Domain.Abstraction.Repositories;
using LibraryService.Domain.AggregatesModel.LibraryAggregate;
using LibraryService.Persistence.EntityFramework.Contexts;

namespace LibraryService.Persistence.EntityFramework.Repositories;

public class EFLibraryBookRepository : EFBaseRepository<LibraryBook, LibraryServiceContext>, ILibraryBookRepository
{
    
}