using Ludotek.Repositories.Interfaces;
using Ludotek.Repositories.Respositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RegisterRepositoriesExtension
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWheelRepository, WheelRepository>();

            return services;
        }
    }
}
