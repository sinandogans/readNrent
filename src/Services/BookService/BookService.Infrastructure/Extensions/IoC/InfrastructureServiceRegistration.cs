using BookService.Application.Abstraction.Infrastructure.FileOperations;
using BookService.Infrastructure.FileOperations;
using Microsoft.Extensions.DependencyInjection;

namespace BookService.Infrastructure.Extensions.IoC
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddScoped<IFileHelper, FileHelper>();
        }
    }
}
