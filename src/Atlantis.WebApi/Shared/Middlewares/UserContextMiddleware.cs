namespace Atlantis.WebApi.Shared.Middlewares
{
    using Atlantis.WebApi.Shared.Context.Factories;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Primitives;
    using System;
    using System.Threading.Tasks;

    public class UserContextMiddleware
    {
        private const string UserKey = "user-key";

        private readonly RequestDelegate _next;
        //private readonly IUserContextFactory _userContextFactory;

        public UserContextMiddleware(RequestDelegate next)
        {
            _next = next;
            //_userContextFactory = userContextFactory;
        }

        public async Task Invoke(HttpContext httpContext, IUserContextFactory userContextFactory)
        {
            // Extract UserKey from HttpRequest
            //var userContextFactory = httpContext.RequestServices.GetRequiredService<IUserContextFactory>();
            var headers = httpContext.Request.Headers;
            Guid key = Guid.Empty;
            if (headers.TryGetValue(UserKey, out var value) && !StringValues.IsNullOrEmpty(value))
            {
                var keys = value.ToString().Split(',');
                if (keys.Length > 1)
                    throw new InvalidOperationException($"{UserKey} must contain only 1 value.");
                if (!Guid.TryParse(keys[0], out key))
                    throw new ArgumentException($"{UserKey} is invalid.");
            }
            else
            {
                key = Guid.NewGuid();
                value = new StringValues(key.ToString());
            }

            // Create and set UserContext
            //_userContextFactory.Create(key);
            userContextFactory.Create(key);

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
