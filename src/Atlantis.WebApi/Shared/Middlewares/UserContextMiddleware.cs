namespace Atlantis.WebApi.Shared.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;
    using System;
    using System.Threading.Tasks;

    public class UserContextMiddleware
    {
        private const string UserKey = "user-key";
        private readonly RequestDelegate _next;

        public UserContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            // Extract UserKey from HttpRequest
            var headers = httpContext.Request.Headers;
            if (!headers.TryGetValue(UserKey, out var value))
            {
                value = new StringValues(Guid.NewGuid().ToString());
            }
            if (StringValues.IsNullOrEmpty(value))
            {
                // set it to new GUID
                value = new StringValues(Guid.NewGuid().ToString());
            }

            // use it to create the user contex.

            // Set UserKey-> key/value to HttpResponse header.
            httpContext.Response.OnStarting(() =>
            {
                httpContext.Response.Headers.Add(UserKey, value);
                return Task.CompletedTask;
            });

            // Call the next middleware in the pipeline
            await _next(httpContext);
        }
    }
}
