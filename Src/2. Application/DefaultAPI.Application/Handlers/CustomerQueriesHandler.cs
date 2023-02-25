using DefaultAPI.Application.Interfaces;
using DefaultAPI.Application.Queries;
using DefaultAPI.Domain.Entities;
using DefaultAPI.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DefaultAPI.Application.Handlers
{
    public class CustomerQueriesHandler : IRequestHandler<CustomerQueryById, Customer>
        , IRequestHandler<CustomerQueryAll, IEnumerable<Customer>>

        , IRequestHandler<CustomerQueryPage, PagedResult<Customer>>
    {
        private ICustomerService _CustomerService;

        public CustomerQueriesHandler(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }



        public async Task<Customer> Handle(CustomerQueryById request, CancellationToken cancellationToken)
        {
            var list = await _CustomerService.GetAllCustomer();
            if (list != null)
            {
                return list[0];
            }
            return null;
        }

        public async Task<IEnumerable<Customer>> Handle(CustomerQueryAll request, CancellationToken cancellationToken)
        {
            var list = await _CustomerService.GetAllCustomer();
            if (list != null)
            {
                return list;
            }
            return null;
        }

        public async Task<PagedResult<Customer>> Handle(CustomerQueryPage request, CancellationToken cancellationToken)
        {
            var list = await _CustomerService.GetAllWithPaginate(request);
            if (list != null)
            {
                return list;
            }
            return null;
        }
    }
}