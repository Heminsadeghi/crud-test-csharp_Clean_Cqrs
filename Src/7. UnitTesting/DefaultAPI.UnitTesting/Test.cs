
using DefaultAPI.Application.Interfaces;
using DefaultAPI.Application.Queries;
using DefaultAPI.Application.Services;
using DefaultAPI.Domain;
using DefaultAPI.Domain.Entities;
using DefaultAPI.Infra.Data.Context;
using DefaultAPI.Infra.Data.Repositories;
using DefaultCQRSAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DefaultAPI.UnitTesting
{
    public class UnitTestController
    {

        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ICustomerService> _customerQueriesMock;
     
        public UnitTestController()
        {
            _mediatorMock = new Mock<IMediator>();
            _customerQueriesMock = new Mock<ICustomerService>();

           
        }

        [Fact]
        public void GetcustomerList_customerList()
        {
            //arrange
            var customerList = GetcustomersData();
            List<Customer> customers = new List<Customer>();


            //act
            var fakeDynamicResult = new List<Customer>();





            _customerQueriesMock.Setup(x => x.GetAllCustomer())
    .Returns(Task.FromResult(fakeDynamicResult));

            //Act
            var customersController = new CustomerController(null, _mediatorMock.Object);
            var actionResult = customersController.GetAll();

            //Assert
            Assert.Equal((decimal)actionResult.Status, (int)System.Net.HttpStatusCode.OK);



        }





        [Fact]
        public void CheckEmailcustomer_customer()
        {
            //arrange
            Customer customer = new Customer();
            customer.Firstname = "TEst_FirtName";
            customer.Lastname = "TEst_Lastname";
            customer.Email = "TEst_Email_dd";
            customer.PhoneNumber = "09121111111";
            customer.BankAccountNumber = "1234567898";
            customer.DateOfBirth = DateTime.Now;

            //act
            string Message = "";
            _customerQueriesMock.Setup(x => x.Add(customer).Result)
                .Returns(Message);


            //assert
            Assert.NotEmpty(Message);
            Assert.True(Message == Constants.EmailIsExists);

        }


        [Fact]
        public void CheckAddcustomer_customer()
        {
            //arrange
            Customer customer = new Customer();
            customer.Id = 1;

            customer.Firstname = "TEst_FirtName";
            customer.Lastname = "TEst_Lastname";
            customer.Email = "TEst_Email_dd";
            customer.PhoneNumber = "09121111111";
            customer.BankAccountNumber = "1234567898";
            customer.DateOfBirth = DateTime.Now;

            //act
            string Message = "";
            _customerQueriesMock.Setup(x => x.Add(customer).Result)
                .Returns(Message);


            //assert
            Assert.NotEmpty(Message);
            Assert.True(Message == Constants.EmailIsExists);

        }



        [Fact]
        public void CheckUpdatecustomer_customer()
        {
            //arrange
            Customer customer = new Customer();
            customer.Id = 1;

            customer.Firstname = "TEst_FirtName";
            customer.Lastname = "TEst_Lastname";
            customer.Email = "TEst_Email_dd";
            customer.PhoneNumber = "09121111111";
            customer.BankAccountNumber = "1234567898";
            customer.DateOfBirth = DateTime.Now;

            //act
            string Message = "";
            _customerQueriesMock.Setup(x => x.Update(customer).Result)
                .Returns(Message);


            //assert
            Assert.NotEmpty(Message);
            Assert.True(Message == Constants.EmailIsExists);

        }



        private List<Customer> GetcustomersData()
        {
            List<Customer> customersData = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Firstname = "IPhone",
                Lastname = "IPhone 12",
                PhoneNumber = "555",
                Email = "aaa@aa.com",
                BankAccountNumber = "123456789",
                DateOfBirth =DateTime.Parse( "2022-05-27")

            },
             new Customer
            {
                 Id = 2,
                 Firstname = "IPhone",
                Lastname = "IPhone 12",
                PhoneNumber = "555",
                Email = "aaa@aa.com",
                BankAccountNumber = "123456789",
                DateOfBirth =DateTime.Parse( "2022-05-27")
            },
             new Customer
            {
                 Id = 3,
                Firstname = "IPhone",
                Lastname = "IPhone 12",
                PhoneNumber = "555",
                Email = "aaa@aa.com",
                BankAccountNumber = "123456789",
                DateOfBirth =DateTime.Parse( "2022-05-27")
            },
        };
            return customersData;
        }
    }
}

