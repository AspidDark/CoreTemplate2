using System.Collections.Generic;
using NetCoreConfiguringTemplate2.Responses;
using MediatR;

namespace NetCoreConfiguringTemplate2.Queries
{
    public class GetAllOrdersQuery : IRequest<List<OrderResponse>>
    {
        
    }
}