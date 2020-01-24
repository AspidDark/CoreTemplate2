using System;
using NetCoreConfiguringTemplate2.Responses;
using MediatR;

namespace NetCoreConfiguringTemplate2.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponse>
    {
        public Guid CustomerId { get; }

        public GetCustomerByIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}