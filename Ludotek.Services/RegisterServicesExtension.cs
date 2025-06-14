﻿using Ludotek.Services;
using Ludotek.Services.Interfaces;
using Ludotek.Services.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RegisterServicesExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IImportService, ImportService>();
            services.AddScoped<ILudothequeService, LudothequeService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IWheelService, WheelService>();

            return services;
        }
    }
}
