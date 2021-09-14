namespace Atlantis.WebApi.Order.Business
{
    public interface IOrderService
    {
        bool OrderPlacement(OrderDomainModel model);
    }
}
