using BookService.Application.Abstraction.Persistence.AuthorRepository;
using BookService.Application.Abstraction.Persistence.AuthorReviewRepository;
using BookService.Application.Abstraction.Persistence.BookImageRepository;
using BookService.Application.Abstraction.Persistence.BookRepository;
using BookService.Application.Abstraction.Persistence.BookReviewRepository;
using BookService.Application.Abstraction.Persistence.GenreRepository;
using BookService.Application.Abstraction.Persistence.PublisherRepository;
using BookService.Application.Abstraction.Persistence.PublishRepository;
using BookService.Application.Abstraction.Persistence.UserRepository;
using BookService.Persistence.MongoDbDriver.Context;
using BookService.Persistence.MongoDbDriver.Repositories.AuthorRepository;
using BookService.Persistence.MongoDbDriver.Repositories.AuthorReviewRepository;
using BookService.Persistence.MongoDbDriver.Repositories.BookImageRepository;
using BookService.Persistence.MongoDbDriver.Repositories.BookRepository;
using BookService.Persistence.MongoDbDriver.Repositories.BookReviewRepository;
using BookService.Persistence.MongoDbDriver.Repositories.GenreRepository;
using BookService.Persistence.MongoDbDriver.Repositories.PublisherRepository;
using BookService.Persistence.MongoDbDriver.Repositories.PublishRepository;
using BookService.Persistence.MongoDbDriver.Repositories.UserRepository;
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
            services.AddSingleton<IPublishRepository, MDBPublishRepository>();
            services.AddSingleton<IBookImageRepository, MDBBookImageRepository>();
            services.AddSingleton<IBookReviewRepository, MDBBookReviewRepository>();
            services.AddSingleton<IAuthorRepository, MDBAuthorRepository>();
            services.AddSingleton<IUserRepository, MDBUserRepository>();
            services.AddSingleton<IAuthorReviewRepository, MDBAuthorReviewRepository>();
        }
    }
}