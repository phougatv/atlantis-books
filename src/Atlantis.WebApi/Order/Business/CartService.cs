namespace Atlantis.WebApi.Order.Business
{
    using Atlantis.WebApi.Shared.Context.Accessors;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;

    internal class CartService : ICartService
    {
        private readonly ILogger<CartService> _logger;
        private readonly Guid _userKey;

        private readonly IDictionary<Guid, CartDomainModel> _cartMap;

        public CartService(
            ILogger<CartService> logger,
            IUserContextAccessor userContextAccessor)
        {
            _logger = logger;
            _userKey = userContextAccessor.UserContext.UserKey;
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
            _cartMap.Add(_userKey, model);

            return model.CartId;
        }

        CartDomainModel ICartService.Get()
        {
            if (!_cartMap.TryGetValue(_userKey, out var model))
            {
                _logger.LogInformation($"Cart does not exists for {nameof(_userKey)}: {_userKey}.");
                return null;
            }
            return model;
        }

        bool ICartService.Update(CartDomainModel modelToBeUpdated)
        {
            if (!_cartMap.ContainsKey(_userKey))
            {
                _logger.LogInformation($"CartId does not exists for {nameof(_userKey)}: {_userKey}.");
                return false;
            }

            var model = _cartMap[_userKey];
            if (model.CartId == modelToBeUpdated.CartId)
                _cartMap[_userKey] = modelToBeUpdated;

            return true;
        }
    }
}
