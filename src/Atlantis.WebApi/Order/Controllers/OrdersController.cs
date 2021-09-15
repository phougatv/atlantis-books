﻿namespace Atlantis.WebApi.Order.Controllers
{
    using Atlantis.WebApi.Order.Business;
    using Atlantis.WebApi.Order.Dtos;
    using Atlantis.WebApi.Shared.Context.Accessors;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly IUserContextAccessor _userContextAccessor;

        public OrdersController(
            IMapper mapper,
            IOrderService orderService,
            ICartService cartService,
            IUserContextAccessor userContextAccessor)
        {
            _mapper = mapper;
            _orderService = orderService;
            _cartService = cartService;
            _userContextAccessor = userContextAccessor;
        }

        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Order pinged!!!");
        }

        [HttpPost("add-to-cart")]
        public IActionResult AddToCart([FromBody] CartAddDto cartAddDto)
        {
            var model = _mapper.Map<CartDomainModel>(cartAddDto);
            model.UserKey = _userContextAccessor.UserContext.UserKey;
            var cartId = _cartService.Create(model);

            return Ok(cartId);
        }

        [HttpPut("update-cart")]
        public IActionResult UpdateCart([FromBody] CartUpdateDto cartUpdateDto)
        {
            var model = _mapper.Map<CartDomainModel>(cartUpdateDto);
            model.UserKey = _userContextAccessor.UserContext.UserKey;
            var isCartUpdated = _cartService.Update(model);

            return Ok(isCartUpdated);
        }

        [HttpPost("checkout")]
        public IActionResult PlaceOrder([FromBody] OrderDto dto)
        {
            var model = _mapper.Map<OrderDomainModel>(dto);
            model.UserKey = _userContextAccessor.UserContext.UserKey;
            var isCheckedOut = _orderService.OrderPlacement(model);

            return Ok(isCheckedOut);
        }
    }
}
