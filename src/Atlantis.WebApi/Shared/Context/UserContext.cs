namespace Atlantis.WebApi.Shared.Context
{
    using System;

    public class UserContext
    {
        public Guid UserKey { get; }
        public UserContext(Guid userKey)
        {
            UserKey = userKey;
        }
    }
}
