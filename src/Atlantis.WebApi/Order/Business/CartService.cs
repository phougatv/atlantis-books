namespace Atlantis.WebApi.Order.Business
{
    using Atlantis.WebApi.Shared.Context.Accessors;
    using Atlantis.WebApi.Shared.Extensions;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;

    internal class CartService : ICartService
    {
        private readonly ILogger<CartService> _logger;
        private readonly IUserContextAccessor _userContextAccessor;

        private readonly IDictionary<Guid, CartDomainModel> _cartMap;

        public CartService(
            ILogger<CartService> logger,
            IUserContextAccessor userContextAccessor)
        {
            _logger = logger;
            _userContextAccessor = userContextAccessor;
            _cartMap = new Dictionary<Guid, CartDomainModel>();
        }

        Guid ICartService.Create(CartDomainModel model)
        {
            if (model.CartId.IsEmpty())
            {
                _logger.LogInformation("CartId must be empty guid. Cannot add to cart.");
                return Guid.Empty;
            }

            model.CartId = Guid.NewGuid();
            _cartMap.Add(_userContextAccessor.UserContext.UserKey, model);

            return model.CartId;
        }

        CartDomainModel ICartService.Get()
        {
            if (!_cartMap.TryGetValue(_userContextAccessor.UserContext.UserKey, out var model))
            {
                _logger.LogInformation($"Cart does not exists for {nameof(_userContextAccessor.UserContext.UserKey)}: {_userContextAccessor.UserContext.UserKey}.");
                return null;
            }
            return model;
        }

        bool ICartService.Update(CartDomainModel modelToBeUpdated)
        {
            if (!_cartMap.ContainsKey(_userContextAccessor.UserContext.UserKey))
            {
                _logger.LogInformation($"CartId does not exists for {nameof(_userContextAccessor.UserContext.UserKey)}: {_userContextAccessor.UserContext.UserKey}.");
                return false;
            }

            var model = _cartMap[_userContextAccessor.UserContext.UserKey];
            if (model.CartId == modelToBeUpdated.CartId)
                _cartMap[_userContextAccessor.UserContext.UserKey] = modelToBeUpdated;

            return true;
        }
    }
}
