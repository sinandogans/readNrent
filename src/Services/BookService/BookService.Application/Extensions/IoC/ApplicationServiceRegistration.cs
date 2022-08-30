using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookService.Application.Extensions.IoC
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);
        }
    }
}
