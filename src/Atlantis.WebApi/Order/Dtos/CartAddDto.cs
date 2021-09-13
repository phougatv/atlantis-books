namespace Atlantis.WebApi.Order.Dtos
{
    using System;
    using System.Collections.Generic;

    public class CartAddDto
    {
        public Guid UserKey { get; set; }
        public IEnumerable<Guid> BookIds { get; set; }
    }
}
