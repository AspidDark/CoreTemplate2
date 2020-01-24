using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreConfiguringTemplate2.Dtos;

namespace NetCoreConfiguringTemplate2.Repositories
{
    public interface IOrdersRepository
    {
        Task<List<OrderDto>> GetOrdersAsync();

        Task<OrderDto> CreateOrderAsync(Guid customerId, Guid productId);
        
        Task<OrderDto> GetOrderAsync(Guid orderId);
    }
}