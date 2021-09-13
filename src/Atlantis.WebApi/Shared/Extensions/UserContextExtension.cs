namespace Atlantis.WebApi.Shared.Extensions
{
    using Atlantis.WebApi.Shared.Middlewares;
    using Microsoft.AspNetCore.Builder;

    public static class UserContextExtension
    {
        public static IApplicationBuilder UseUserContext(this IApplicationBuilder app) => app.UseMiddleware<UserContextMiddleware>();
    }
}
