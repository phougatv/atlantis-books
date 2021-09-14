namespace Atlantis.WebApi.Order.Persistence
{
    using Atlantis.WebApi.Shared.DataAccess.Base;
    using System;

    internal class Order : Entity<Guid>
    {
        public Guid CartId { get; set; }
        public Guid UserKey { get; set; }
        public string BookIds { get; set; }
    }
}
