using DefaultAPI.Domain.Entities;
using DefaultAPI.Domain.Filters;
using DefaultAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultAPI.Application.Interfaces
{
    public interface ICustomerService : IDisposable
    {
        Task AddCustomers(List<Customer> list);

        Task<List<Customer>> GetAllCustomer();

        //  Task RefreshCustomer(List<States> listStatesAPI);

        Task<bool> UpdateStatusById(long id);

        Task<List<Customer>> GetAllWithLike(string parametro);

        Task<PagedResult<Customer>> GetAllWithPaginate(CustomerFilter filter);

        Task<string> Add(Customer customer);


        Task  Remove(long id);

        Task<string> Update(Customer customer);
    }
}
