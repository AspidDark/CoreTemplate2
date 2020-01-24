using System.Threading;
using System.Threading.Tasks;
using NetCoreConfiguringTemplate2.Mapping;
using NetCoreConfiguringTemplate2.Queries;
using NetCoreConfiguringTemplate2.Repositories;
using NetCoreConfiguringTemplate2.Responses;
using MediatR;

namespace NetCoreConfiguringTemplate2.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomersRepository _customersRepository;
    
        public GetCustomerByIdHandler(IMapper mapper, ICustomersRepository customersRepository)
        {
            _mapper = mapper;
            _customersRepository = customersRepository;
        }
        
        public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customerDto = await _customersRepository.GetCustomerAsync(request.CustomerId);
            return customerDto == null ? null : _mapper.MapCustomerDtoToCustomerResponse(customerDto);
        }
    }
}