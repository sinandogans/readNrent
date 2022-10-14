using Microsoft.Extensions.DependencyInjection;
using ReviewService.Application.Abstraction.Persistence.AuthorReviewRepository;
using ReviewService.Application.Abstraction.Persistence.BookReviewRepository;
using ReviewService.Application.Abstraction.Persistence.UserRepository;
using ReviewService.Persistence.MongoDbDriver.Context;
using ReviewService.Persistence.MongoDbDriver.Repositories.AuthorReviewRepository;
using ReviewService.Persistence.MongoDbDriver.Repositories.BookReviewRepository;
using ReviewService.Persistence.MongoDbDriver.Repositories.UserRepository;

namespace ReviewService.Persistence.Extensions.IoC
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbContext>();
            services.AddSingleton<IBookReviewRepository, MDBBookReviewRepository>();
            services.AddSingleton<IUserRepository, MDBUserRepository>();
            services.AddSingleton<IAuthorReviewRepository, MDBAuthorReviewRepository>();
        }
    }
}
