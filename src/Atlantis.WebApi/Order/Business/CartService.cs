namespace Atlantis.WebApi.Order.Business
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;

    internal class CartService : ICartService
    {
        private readonly ILogger<CartService> _logger;

        private readonly IDictionary<Guid, CartDomainModel> _cartMap;

        public CartService(ILogger<CartService> logger)
        {
            _logger = logger;
            _cartMap = new Dictionary<Guid, CartDomainModel>();
        }

        Guid ICartService.Create(CartDomainModel model)
        {
            if (model.CartId != Guid.Empty)
            {
                _logger.LogInformation("CartId must be empty guid. Cannot add to cart.");
                return Guid.Empty;
            }

            model.CartId = Guid.NewGuid();
            _cartMap.Add(model.CartId, model);

            return model.CartId;
        }

        CartDomainModel ICartService.Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogInformation($"{nameof(id)} cannot be an empty guid.");
                return null;
            }
            if (!_cartMap.TryGetValue(id, out var model))
            {
                _logger.LogInformation($"{nameof(id)}: {id}, does not exists.");
                return null;
            }
            return model;
        }

        bool ICartService.Update(CartDomainModel model)
        {
            if (!_cartMap.ContainsKey(model.CartId))
            {
                _logger.LogInformation("CartId does not exist in the cart. Cannot update the cart.");
                return false;
            }

            _cartMap[model.CartId] = model;

            return true;
        }
    }
}
