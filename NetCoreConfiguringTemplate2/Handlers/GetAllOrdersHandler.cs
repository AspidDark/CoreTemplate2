using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NetCoreConfiguringTemplate2.Mapping;
using NetCoreConfiguringTemplate2.Queries;
using NetCoreConfiguringTemplate2.Repositories;
using NetCoreConfiguringTemplate2.Responses;
using MediatR;

namespace NetCoreConfiguringTemplate2.Handlers
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderResponse>>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        
        public GetAllOrdersHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }
        
        public async Task<List<OrderResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _ordersRepository.GetOrdersAsync();
            return _mapper.MapOrderDtosToOrderResponses(orders);
        }
    }
}