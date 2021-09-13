namespace Atlantis.WebApi.Shared.Extensions
{
    using Atlantis.WebApi.Shared.Context.Accessors;
    using Atlantis.WebApi.Shared.Context.Factories;
    using Atlantis.WebApi.Shared.Middlewares;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class UserContextExtension
    {
        public static IServiceCollection AddUserContext(this IServiceCollection services) =>
            services
                .AddSingleton<IUserContextAccessor, UserContextAccessor>()
                .AddSingleton<IUserContextFactory, DefaultUserContextFactory>();

        public static IApplicationBuilder UseUserContext(this IApplicationBuilder app) =>
            app.UseMiddleware<UserContextMiddleware>();
    }
}
