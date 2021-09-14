namespace Atlantis.WebApi
{
    using Atlantis.WebApi.Shared.Extensions;
    using Atlantis.WebApi.Book.Extensions;
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// The startup class.
    /// </summary>
    public class Startup
    {
        /// <summary> The configuration <see cref="IConfiguration"/>. </summary>
        public IConfiguration Configuration { get; }

        /// <summary> The web host environment <see cref="IWebHostEnvironment"/>. </summary>
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary> The logger <see cref="ILogger{Startup}"/>. </summary>
        public ILogger<Startup> Logger { get; }

        /// <summary>
        /// Ctor of Startup class.
        /// </summary>
        /// <param name="configuration"><paramref name="configuration"/></param>
        /// <param name="webHostEnvironment"><paramref name="webHostEnvironment"/></param>
        /// <param name="logger"><paramref name="logger"/></param>
        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment,
            ILogger<Startup> logger)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
            Logger = logger;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddAtlantisBook(Configuration);

            AddAtlantisAutomapper(services);

            services
                .AddUserContext();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Atlantis API V1");
                //c.RoutePrefix = string.Empty;         // To serve the Swagger UI at the app's root (http://localhost:<port>/).
            });

            app
                .UseRouting()
                .UseUserContext()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }

        #region Private Static Methods
        private IServiceCollection AddAtlantisAutomapper(IServiceCollection services)
        {
            var atlantisAssemblies = GetAtlantisAssemblies();
            var mapper = GetMapper(atlantisAssemblies);
            services.AddSingleton(mapper);

            return services;
        }

        private IMapper GetMapper(IEnumerable<Assembly> atlantisAssemblies) =>
            new MapperConfiguration(configExp => configExp.AddMaps(atlantisAssemblies.ToArray()))
                .CreateMapper();

        private IEnumerable<Assembly> GetAtlantisAssemblies() =>
            AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(assembly => assembly.GetName().FullName.StartsWith("Atlantis."));
        #endregion
    }
}
