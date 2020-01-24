using System;
using NetCoreConfiguringTemplate2.Responses;
using MediatR;

namespace NetCoreConfiguringTemplate2.Queries
{
    public class GetCustomerOrdersQuery : IRequest<CustomerOrdersResponse>
    {
        public Guid CustomerId { get; }
        
        public GetCustomerOrdersQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}