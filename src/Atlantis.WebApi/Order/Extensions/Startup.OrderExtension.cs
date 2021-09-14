namespace Atlantis.WebApi.Order.Extensions
{
    using Atlantis.WebApi.Order.Business;
    using Atlantis.WebApi.Order.Persistence;
    using Microsoft.Extensions.DependencyInjection;

    internal static class OrderExtension
    {
        internal static IServiceCollection AddAtlantisOrder(this IServiceCollection services)
        {
            services
                .AddScoped<ICartService, CartService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
