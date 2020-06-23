using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementBackEnd.Models;

namespace UserManagementBackEnd.Data
{
    public interface ICustomersRepository
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> InsertCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<PagingResult<Customer>> GetCustomersPageAsync(int skip, int take);
    }
}
