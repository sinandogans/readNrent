using LibraryService.Domain.Abstraction.Repositories;
using LibraryService.Persistence.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, EFBookRepository>();
            services.AddSingleton<IAuthorRepository, EFAuthorRepository>();
            services.AddSingleton<IUserRepository, EFUserRepository>();
            services.AddSingleton<ILibraryBookRepository, EFLibraryBookRepository>();
        }
    }
}