using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Application.Abstraction.Persistence.LanguageRepository;
using BookService.Application.Abstraction.Persistence.PublisherRepository;
using BookService.Persistence.EntityFramework.Repositories.BookRepository;
using BookService.Persistence.EntityFramework.Repositories.GenreRepository;
using BookService.Persistence.EntityFramework.Repositories.LanguageRepository;
using BookService.Persistence.EntityFramework.Repositories.PublisherRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BookService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, EfBookRepository>();

            services.AddSingleton<IGenreRepository, EfGenreRepository>();

            services.AddSingleton<IPublisherRepository, EfPublisherRepository>();
            services.AddSingleton<ILanguageRepository, EFLanguageRepository>();
        }
    }
}
