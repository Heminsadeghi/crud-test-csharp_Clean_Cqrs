using DefaultAPI.Application.Factory;
using DefaultAPI.Application.Interfaces;
using DefaultAPI.Domain;
using DefaultAPI.Domain.Entities;
using DefaultAPI.Domain.Filters;
using DefaultAPI.Domain.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DefaultAPI.Application.Services
{
    public class CustomerService :   ICustomerService
    {
        //private readonly INotificationMessageService _notificationMessageService;


        public readonly ICustomerRepository _CustomerRepository;

        public CustomerService(ICustomerRepository CustomerRepository) 
        {
            _CustomerRepository = CustomerRepository;
        }



        public async Task<List<Customer>> GetAllCustomer()
        {
            return await _CustomerRepository.GetAll().ToListAsync();
        }

        public Task AddCustomers(List<Customer> list)
        {
            _CustomerRepository.AddRange(list);
            _CustomerRepository.SaveChanges();
            return Task.CompletedTask;
        }


        public async Task<bool> UpdateStatusById(long id)
        {
            try
            {
                Customer record = await Task.FromResult(_CustomerRepository.GetById(id));
                if (record != null)
                {
                    record.IsActive = record.IsActive == true ? false : true;
                    _CustomerRepository.Update(record);
                    _CustomerRepository.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Customer>> GetAllWithLike(string parametro) => await _CustomerRepository.GetAllWithLike(parametro);

        public async Task<PagedResult<Customer>> GetAllWithPaginate(CustomerFilter filter)
        {
            try
            {
                var query = await GetAllWithFilter(filter);
                var queryCount = await GetCount(filter);

                var queryResult = from x in query.AsQueryable()
                                  orderby x.Firstname ascending
                                  select new Customer
                                  {
                                      Id = x.Id,
                                      Firstname = x.Firstname,
                                      Lastname = x.Lastname,
                                      DateOfBirth = x.DateOfBirth,
                                      Email = x.Email,
                                      PhoneNumber = x.PhoneNumber,
                                      BankAccountNumber = x.BankAccountNumber,

                                      IsActive = x.IsActive
                                  };

                return PagedFactory.GetPaged(queryResult, filter.pageIndex, filter.pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private async Task<IQueryable<Customer>> GetAllWithFilter(CustomerFilter filter)
        {
            return await Task.FromResult(_CustomerRepository.GetAll().Where(GetPredicate(filter)).AsQueryable());
        }

        private async Task<int> GetCount(CustomerFilter filter)
        {
            return await _CustomerRepository.GetAll().CountAsync(GetPredicate(filter));
        }

        private Expression<Func<Customer, bool>> GetPredicate(CustomerFilter filter)
        {
            return p =>
                   (string.IsNullOrWhiteSpace(filter.FirstName) || p.Firstname.Trim().ToUpper().StartsWith(filter.FirstName.Trim().ToUpper()));
        }


        public async Task<string> Add(Customer customer)
        {

            Customer _ValidEmailcustomer = await _CustomerRepository.FindBy(x => x.Email.ToUpper() == customer.Email.ToUpper().Trim()).FirstOrDefaultAsync();
            if (_ValidEmailcustomer is not null)
            {
                return Constants.EmailIsExists;
              
            }

            Customer _Validcustomer = await _CustomerRepository.FindBy(x => x.Firstname.ToUpper() == customer.Firstname.ToUpper().Trim()
            && x.Lastname.ToUpper() == customer.Lastname.ToUpper().Trim()
            && x.DateOfBirth == customer.DateOfBirth
            ).FirstOrDefaultAsync();

            if (_Validcustomer is not null)
            {
                return Constants.CustomerIsExists;
             
            }


            customer.CreatedTime = DateTime.Now;
            _CustomerRepository.Add(customer);
            var added = _CustomerRepository.SaveChanges();
            await Task.CompletedTask;
            return "";
        }

        public Task Remove(long id)
        {
            Customer customer = _CustomerRepository.GetById(id);

            if (customer is not null)
                _CustomerRepository.Remove(customer);

            return Task.CompletedTask;
        }

        public async Task<string> Update(Customer customer)
        {
            Customer entityBase = _CustomerRepository.FindBy(a => a.Id == customer.Id).FirstOrDefault();

            if (entityBase is null)
            {
                return Constants.CustomerNotIsExists;
                
            }


            Customer _ValidEmailcustomer = await _CustomerRepository.FindBy(x => x.Email.ToUpper() == customer.Email.ToUpper().Trim()).FirstOrDefaultAsync();
            if (_ValidEmailcustomer is not null && _ValidEmailcustomer.Id != entityBase.Id)
            {
                return Constants.EmailIsExists;
             
            }

            Customer _Validcustomer = await _CustomerRepository.FindBy(x => x.Firstname.ToUpper() == customer.Firstname.ToUpper().Trim()
            && x.Lastname.ToUpper() == customer.Lastname.ToUpper().Trim()
            && x.DateOfBirth == customer.DateOfBirth
            ).FirstOrDefaultAsync();

            if (_Validcustomer is not null && _Validcustomer.Id != entityBase.Id)
            {
                return Constants.CustomerIsExists;
             
            }

           
            if (entityBase != null)
            {
                entityBase.Firstname = customer.Firstname;
                entityBase.Lastname = customer.Lastname;
                entityBase.Email = customer.Email;
                entityBase.BankAccountNumber = customer.BankAccountNumber;
                entityBase.DateOfBirth = customer.DateOfBirth;
                entityBase.PhoneNumber = customer.PhoneNumber;

                _CustomerRepository.Update(entityBase);
                _CustomerRepository.SaveChanges();
            }

            _CustomerRepository.Update(entityBase);
            var updated = _CustomerRepository.SaveChanges();


            await Task.CompletedTask;

            return "";


        }



        public void Dispose()
        {
            _CustomerRepository?.Dispose();
        }

       
    }
}
