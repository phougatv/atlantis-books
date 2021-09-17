namespace Atlantis.WebApi.Order.Business
{
    using System;

    public interface ICartService
    {
        Guid Create(CartDomainModel model);
        CartDomainModel Get(Guid cartId);
        bool IsEmpty();
        bool Update(CartDomainModel model);
    }
}
