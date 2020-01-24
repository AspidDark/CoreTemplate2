using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreConfiguringTemplate2.Dtos;

namespace NetCoreConfiguringTemplate2.Repositories
{
    public interface ICustomersRepository
    {
        Task<CustomerDto> GetCustomerAsync(Guid customerId);
        
        Task<List<CustomerDto>> GetCustomersAsync();
    }
}