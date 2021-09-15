namespace Atlantis.WebApi.Order.Business
{
    using Atlantis.WebApi.Order.Persistence;
    using Atlantis.WebApi.Shared.DataAccess.UnitOfWork;
    using AutoMapper;
    using System;

    class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly ICartService _cartService;
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            IMapper mapper,
            IUnitOfWork uow,
            ICartService cartService,
            IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _uow = uow;
            _cartService = cartService;
            _orderRepository = orderRepository;
        }

        bool IOrderService.OrderPlacement(OrderDomainModel orderModel)
        {
            var cartModel = _cartService.Get(orderModel.CartId);
            orderModel.InternalSet(cartModel);
            orderModel.OrderId = Guid.NewGuid();

            var order = _mapper.Map<Order>(orderModel);
            var isCreated = _orderRepository.Create(order);
            var affectedRows = _uow.Commit();

            return isCreated && affectedRows == 1;
        }
    }
}
