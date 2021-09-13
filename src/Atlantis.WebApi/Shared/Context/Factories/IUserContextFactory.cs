using System;

namespace Atlantis.WebApi.Shared.Context.Factories
{
    public interface IUserContextFactory
    {
        UserContext Create(Guid userKey);
    }
}
