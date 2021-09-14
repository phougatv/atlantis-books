namespace Atlantis.WebApi.Shared.Extensions
{
    using Atlantis.WebApi.Book.Extensions;
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class SharedExtension
    {
        /// <summary>
        /// Adds all the custom services required by Atlantis (the application).
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        internal static IServiceCollection AddAtlantis(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAtlantisBook(configuration)
                .AddAtlantisAutomapper()
                .AddUserContext()
                .AddSwaggerGen();   // Register the Swagger generator, defining 1 or more Swagger documents

            return services;
        }

        /// <summary>
        /// Configures custom middlewares to the HTTP request pipeline, which are required by Atlantis.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        internal static IApplicationBuilder UseAtlantis(this IApplicationBuilder app, IConfiguration configuration, ILogger logger) =>
            app
                .UseSwagger(configuration, logger)
                .UseUserContext();

        #region Private IServiceCollection Extension Methods
        private static IServiceCollection AddAtlantisAutomapper(this IServiceCollection services)
        {
            var atlantisAssemblies = GetAtlantisAssemblies();
            var mapper = GetMapper(atlantisAssemblies);
            services.AddSingleton(mapper);

            return services;
        }

        private static IMapper GetMapper(IEnumerable<Assembly> atlantisAssemblies) =>
            new MapperConfiguration(configExp => configExp.AddMaps(atlantisAssemblies.ToArray()))
                .CreateMapper();

        private static IEnumerable<Assembly> GetAtlantisAssemblies() =>
            AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(assembly => assembly.GetName().FullName.StartsWith("Atlantis."));
        #endregion Private IServiceCollection Extension Methods

        #region Private IApplicationBuilder Extension Methods
        private static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IConfiguration configuration, ILogger logger)
        {
            logger.LogInformation("Swagger: Configuring...");

            app
                .UseSwagger()   // Enable middleware to serve generated Swagger as a JSON endpoint.
                .UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Atlantis API V1"));   // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.

            logger.LogInformation("Swagger: Successfully configured.");

            return app;
        }
        #endregion Private IApplicationBuilder Extension Methods
    }
}
