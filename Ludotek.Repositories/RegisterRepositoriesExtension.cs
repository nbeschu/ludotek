using Ludotek.Repositories.Interfaces;
using Ludotek.Repositories.Respositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RegisterRepositoriesExtension
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILudothequeRepository, LudothequeRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IWheelRepository, WheelRepository>();

            return services;
        }
    }
}
