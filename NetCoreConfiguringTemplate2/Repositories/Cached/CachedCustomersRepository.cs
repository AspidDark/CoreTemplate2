using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreConfiguringTemplate2.Dtos;

namespace NetCoreConfiguringTemplate2.Repositories.Cached
{
    public class CachedCustomersRepository : ICustomersRepository
    {
        private readonly ICustomersRepository _customersRepository; //CustomersRepository
        private readonly ConcurrentDictionary<Guid, CustomerDto> _cache = new ConcurrentDictionary<Guid, CustomerDto>();

        public CachedCustomersRepository(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<CustomerDto> GetCustomerAsync(Guid customerId)
        {
            if (_cache.ContainsKey(customerId))
            {
                return _cache[customerId];
            }

            var customer = await _customersRepository.GetCustomerAsync(customerId);//GetOrAdd
            _cache.TryAdd(customerId, customer);
            return customer;
        }

        public async Task<List<CustomerDto>> GetCustomersAsync()
        {
            var customers = await _customersRepository.GetCustomersAsync(); //direct implementation
            return customers;
        }
    }
}
