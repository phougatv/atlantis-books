namespace Atlantis.WebApi.Order.Persistence
{
    using Atlantis.WebApi.Book.Persistence;
    using Atlantis.WebApi.Shared.DataAccess.Base.Repository;
    using System;

    internal class OrderRepository : EfRepository<Order, Guid>, IOrderRepository
    {
        public OrderRepository(AtlantisDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
