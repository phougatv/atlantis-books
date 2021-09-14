namespace Atlantis.WebApi.Order.Business
{
    using Atlantis.WebApi.Order.Persistence;
    using AutoMapper;
    using System;

    class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            IMapper mapper,
            ICartService cartService,
            IOrderRepository orderRepository)
        {
            _mapper = mapper;
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

            return isCreated;
        }
    }
}
