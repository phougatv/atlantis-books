namespace Atlantis.WebApi.Order.Dtos
{
    using System;
    using System.Collections.Generic;

    public class CartAddDto
    {
        public IEnumerable<Guid> BookIds { get; set; }
    }
}
