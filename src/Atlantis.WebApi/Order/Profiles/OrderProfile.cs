namespace Atlantis.WebApi.Order.Profiles
{
    using Atlantis.WebApi.Order.Business;
    using Atlantis.WebApi.Order.Dtos;
    using Atlantis.WebApi.Order.Persistence;
    using AutoMapper;

    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CartAddDto, CartDomainModel>();
            CreateMap<CartUpdateDto, CartDomainModel>();
            CreateMap<OrderDto, OrderDomainModel>();
            CreateMap<OrderDomainModel, Order>();
        }
    }
}
