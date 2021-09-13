namespace Atlantis.WebApi.Shared.Context.Accessors
{
    using System.Threading;

    public class UserContextAccessor : IUserContextAccessor
    {
        private class UserContextHolder
        {
            public UserContext? Context;
        }

        private static readonly AsyncLocal<UserContextHolder> _userContextCurrent = new AsyncLocal<UserContextHolder>();

        public UserContext UserContext
        {
            get
            {
                return _userContextCurrent.Value?.Context;
            }
            set
            {
                var holder = _userContextCurrent.Value;
                if (holder != null)
                {
                    // Clear current UserContext trapped in the AsyncLocals, as its done.
                    holder.Context = null;
                }
                if (value != null)
                {
                    // Use an object indirection to hold the UserContext in the AsyncLocal,
                    // so it can be cleared in all ExecutionContexts when its cleared.
                    _userContextCurrent.Value = new UserContextHolder { Context = value };
                }
            }
        }


    }
}
