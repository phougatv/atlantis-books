namespace Atlantis.WebApi.Order.Dtos
{
    using System;
    using System.Collections.Generic;

    public class CartUpdateDto
    {
        public Guid CartId { get; set; }
        public IEnumerable<Guid> BookIds { get; set; }
    }
}
