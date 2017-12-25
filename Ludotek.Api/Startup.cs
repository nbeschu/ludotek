using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Ludotek.Api.Business;
using Ludotek.Api.Dao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Ludotek.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Ajout des dbContext de l'application
        /// </summary>
        private void EnregistrementContext(IServiceCollection services)
        {
            // Enregistrement du Context
            services.AddScoped<Context>();
        }

        /// <summary>
        /// Ajout des Business de l'application
        /// </summary>
        private void EnregistrementBusiness(IServiceCollection services)
        {
            // Enregistrement des Business
            services.AddScoped(typeof(LudothequeBusiness));
            services.AddScoped(typeof(TagBusiness));
        }

        /// <summary>
        /// Ajout des Dao de l'application
        /// </summary>
        private void EnregistrementDao(IServiceCollection services)
        {
            // Enregistrement des DAO
            services.AddScoped(typeof(LudothequeDao));
            services.AddScoped(typeof(TagDao));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Gestion de la localisation des messages
            services.Configure<RequestLocalizationOptions>(
            opts =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("fr-FR"),
                    new CultureInfo("fr"),
                };

                opts.DefaultRequestCulture = new RequestCulture("fr");
                // Formatting numbers, dates, etc.
                opts.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                opts.SupportedUICultures = supportedCultures;
            });

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            // CORS
            services.AddCors();

            // MVC
            services.AddMvc()
                    .AddJsonOptions(options => { options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; });

            // Connexion à la BDD
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase")));

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Ludothèque", Version = "v1" });
            });

            EnregistrementContext(services);
            EnregistrementBusiness(services);
            EnregistrementDao(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            // Localisation
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // CORS
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ludothèque V1");
            });
        }
    }
}
