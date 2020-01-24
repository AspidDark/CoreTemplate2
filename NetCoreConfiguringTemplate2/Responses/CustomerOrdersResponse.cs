using System;
using System.Collections.Generic;

namespace NetCoreConfiguringTemplate2.Responses
{
    public class CustomerOrdersResponse
    {
        public Guid CustomerId { get; set; }
        
        public List<OrderResponse> Orders { get; set; }
    }
}