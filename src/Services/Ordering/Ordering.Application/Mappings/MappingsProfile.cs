using AutoMapper;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using Ordering.Domain.Enities;

namespace Ordering.Application.Mappings
{
    public  class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
        }
    }
}
