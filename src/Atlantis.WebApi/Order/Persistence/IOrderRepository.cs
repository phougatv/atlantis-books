namespace Atlantis.WebApi.Order.Persistence
{
    using Atlantis.WebApi.Shared.DataAccess.Base.Repository;
    using System;

    internal interface IOrderRepository : IRepository<Order, Guid>
    {

    }
}
