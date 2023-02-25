using DefaultAPI.Application.Interfaces;
using DefaultAPI.Domain.Entities;
using DefaultAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultAPI.Infra.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DefaultAPIContext context) : base(context) { }

        public async Task<List<Customer>> GetAllWithLike(string parametro) => await _context.Customer.Where(x => EF.Functions.Like(x.Firstname, $"%{parametro}%")).ToListAsync();
    }
}
