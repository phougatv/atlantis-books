namespace Atlantis.WebApi.Book.Extensions
{
    using Atlantis.WebApi.Book.Business;
    using Atlantis.WebApi.Book.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal static class BookExtension
    {
        internal static IServiceCollection AddAtlantisBook(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddAtlantisDbContext(configuration)
                .AddScoped<IBookService, BookService>()
                .AddScoped<IBookRepository, BookRepository>();

            return services;
        }

        internal static IServiceCollection AddAtlantisDbContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<AtlantisDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(configuration.GetSection("ConnectionString").Value));
    }
}
