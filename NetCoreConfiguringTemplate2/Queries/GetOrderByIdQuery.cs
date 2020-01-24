using System;
using NetCoreConfiguringTemplate2.Responses;
using MediatR;

namespace NetCoreConfiguringTemplate2.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderResponse>
    {
        public Guid OrderId { get; }
        
        public GetOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }

    }
}