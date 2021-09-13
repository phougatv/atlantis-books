namespace Atlantis.WebApi.Order.Controllers
{
    using Atlantis.WebApi.Order.Dtos;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Order pinged!!!");
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody]CartAddDto cartAddDto)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Checkout([FromBody]CheckoutDto checkoutDto)
        {

        }
    }
}
