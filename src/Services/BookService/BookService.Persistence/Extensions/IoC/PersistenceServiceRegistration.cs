using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Application.Abstraction.Persistence.PublisherRepository;
using BookService.Persistence.EntityFramework.Repositories.BookRepository;
using BookService.Persistence.EntityFramework.Repositories.GenreRepository;
using BookService.Persistence.EntityFramework.Repositories.PublisherRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BookService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IBookReadRepository, EfBookReadRepository>();
            services.AddSingleton<IBookWriteRepository, EfBookWriteRepository>();

            services.AddSingleton<IGenreReadRepository, EfGenreReadRepository>();
            services.AddSingleton<IGenreWriteRepository, EfGenreWriteRepository>();

            //services.AddSingleton<IPublisherReadRepository, EfPublisherReadRepository>();
            services.AddSingleton<IPublisherWriteRepository, EfPublisherWriteRepository>();
        }
    }
}
