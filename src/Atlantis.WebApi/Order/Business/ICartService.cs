namespace Atlantis.WebApi.Order.Business
{
    using System;

    public interface ICartService
    {
        Guid Create(CartDomainModel model);
        CartDomainModel Get();
        bool Update(CartDomainModel model);
    }
}
