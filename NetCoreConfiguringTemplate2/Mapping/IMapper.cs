using System.Collections.Generic;
using NetCoreConfiguringTemplate2.Dtos;
using NetCoreConfiguringTemplate2.Responses;

namespace NetCoreConfiguringTemplate2.Mapping
{
    public interface IMapper
    {
        List<CustomerResponse> MapCustomerDtosToCustomerResponses(List<CustomerDto> dtos);
        
        CustomerResponse MapCustomerDtoToCustomerResponse(CustomerDto customerDto);

        List<OrderResponse> MapOrderDtosToOrderResponses(List<OrderDto> customerOrders);
        
        OrderResponse MapOrderDtoToOrderResponse(OrderDto order);
    }
}