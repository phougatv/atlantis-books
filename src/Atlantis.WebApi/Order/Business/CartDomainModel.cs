namespace Atlantis.WebApi.Order.Business
{
    using System;
    using System.Collections.Generic;

    public class CartDomainModel
    {
        public Guid CartId { get; set; }
        public Guid UserKey { get; set; }
        public IEnumerable<Guid> BookIds { get; set; }
    }
}
