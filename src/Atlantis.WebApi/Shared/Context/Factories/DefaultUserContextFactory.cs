namespace Atlantis.WebApi.Shared.Context.Factories
{
    using Atlantis.WebApi.Shared.Context.Accessors;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class DefaultUserContextFactory : IUserContextFactory
    {
        private readonly IUserContextAccessor? _userContextAccessor;

        public DefaultUserContextFactory(IServiceProvider serviceProvider)
        {
            _userContextAccessor = serviceProvider.GetService<IUserContextAccessor>();
        }

        public UserContext Create(Guid userKey)
        {
            if (userKey == Guid.Empty)
                throw new InvalidOperationException(nameof(userKey), new Exception("Cannot be an empty Guid."));

            var userContext = new UserContext(userKey);
            if (_userContextAccessor != null)
                _userContextAccessor.UserContext = userContext;

            return userContext;
        }
    }
}
