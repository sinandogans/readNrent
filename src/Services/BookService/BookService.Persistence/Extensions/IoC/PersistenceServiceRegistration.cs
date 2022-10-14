using BookService.Application.Abstraction.Persistence.AuthorRepository;
using BookService.Application.Abstraction.Persistence.BookImageRepository;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Application.Abstraction.Persistence.LanguageRepository;
using BookService.Application.Abstraction.Persistence.PublisherRepository;
using BookService.Application.Abstraction.Persistence.PublishRepository;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.AuthorRepository;
using BookService.Persistence.MongoDbDriver.Repositories.BookImageRepository;
using BookService.Persistence.MongoDbDriver.Repositories.BookRepository;
using BookService.Persistence.MongoDbDriver.Repositories.GenreRepository;
using BookService.Persistence.MongoDbDriver.Repositories.LanguageRepository;
using BookService.Persistence.MongoDbDriver.Repositories.PublisherRepository;
using BookService.Persistence.MongoDbDriver.Repositories.PublishRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BookService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbContext>();

            services.AddSingleton<IBookRepository, MDBBookRepository>();
            services.AddSingleton<IGenreRepository, MDBGenreRepository>();
            services.AddSingleton<IPublisherRepository, MDBPublisherRepository>();
            services.AddSingleton<ILanguageRepository, MDBLanguageRepository>();
            services.AddSingleton<IPublishRepository, MDBPublishRepository>();
            services.AddSingleton<IBookImageRepository, MDBBookImageRepository>();
            services.AddSingleton<IAuthorRepository, MDBAuthorRepository>();
        }
    }
}
