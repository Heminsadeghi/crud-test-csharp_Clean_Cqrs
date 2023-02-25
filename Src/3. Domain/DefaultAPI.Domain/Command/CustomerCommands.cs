using DefaultAPI.Domain.Dto;
using DefaultAPI.Domain.Entities;
using DefaultAPI.Domain.Filters;
using DefaultAPI.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultAPI.Domain.Command
{
    public class CustomerCreateCommand : IRequest<ResultReturned>
    {

        public Customer Customer { get; set; }

        public CustomerCreateCommand(CustomerAddDto customer)
        {
            Customer = new Customer();
            Customer.Lastname = customer.Lastname;
            Customer.Firstname = customer.Firstname;
            Customer.Email = customer.Email;
            Customer.BankAccountNumber = customer.BankAccountNumber;
            Customer.PhoneNumber = customer.PhoneNumber;
            Customer.DateOfBirth = customer.DateOfBirth;
         

            // pageSize = CustomerFilter.pageSize;
        }

    }

    public class CustomerUpdateCommand : IRequest<ResultReturned>
    {
        public long? Id { get; set; }
        public Customer Customer { get; set; }



        public CustomerUpdateCommand(CustomerEditDto customeredit)
        {
            Customer = new Customer();
            Customer.Id = customeredit.Id;
            Customer.Lastname = customeredit.Lastname;
            Customer.Firstname = customeredit.Firstname;
            Customer.Email = customeredit.Email;
            Customer.BankAccountNumber = customeredit.BankAccountNumber;
            Customer.PhoneNumber = customeredit.PhoneNumber;
            Customer.DateOfBirth = customeredit.DateOfBirth;


        }

    }

    public class CustomerDeleteCommand : IRequest<ResultReturned>
    {
        public long? Id { get; set; }
        public bool IsDeletePhysical { get; set; }
    }
}
