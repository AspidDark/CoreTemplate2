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
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerResponse>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public GetAllCustomersHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customerDtos = await _customersRepository.GetCustomersAsync();
            return _mapper.MapCustomerDtosToCustomerResponses(customerDtos);
        }
    }
}