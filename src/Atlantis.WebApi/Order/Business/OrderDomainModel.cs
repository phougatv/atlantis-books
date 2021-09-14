namespace Atlantis.WebApi.Order.Business
{
    using System;
    using System.Collections.Generic;

    public class OrderDomainModel
    {
        public Guid OrderId { get; set; }
        public Guid CartId { get; set; }
        public Guid UserKey { get; set; }
        public IEnumerable<Guid> BookIds { get; set; }

        internal void InternalSet(CartDomainModel cartDomainModel)
        {
            UserKey = cartDomainModel.UserKey;
            BookIds = cartDomainModel.BookIds;
        }
    }
}
