using DefaultAPI.Domain.Entities;
using DefaultAPI.Domain.Filters;
using DefaultAPI.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefaultAPI.Application.Queries
{
    public class CustomerQueryById : IRequest<Customer>
    {

        public CustomerQueryById(long Id)
        {
            Id = Id;
        }
        public long? Id { get; set; }
    }

    public class CustomerQueryAll : IRequest<IEnumerable<Customer>>
    {
        public long? Id { get; set; }
    }

    public class CustomerQueryPage : CustomerFilter, IRequest<PagedResult<Customer>>
    {
        public CustomerQueryPage(CustomerFilter CustomerFilter)
        {
            pageIndex = CustomerFilter.pageIndex;
            pageSize = CustomerFilter.pageSize;
        }
    }
}
