using DefaultAPI.Application.Interfaces;
using DefaultAPI.Domain.Command;
using DefaultAPI.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DefaultAPI.Application.Handlers
{
    public class CustomerCommandsHandler : IRequestHandler<CustomerCreateCommand, ResultReturned>, IRequestHandler<CustomerUpdateCommand, ResultReturned>, IRequestHandler<CustomerDeleteCommand, ResultReturned>
    {
        private ICustomerService _CustomerService;

        public CustomerCommandsHandler(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        public async Task<ResultReturned> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var result = new ResultReturned();
            try
            {


                result.Message = await _CustomerService.Add(request.Customer);
                result.Result = String.IsNullOrEmpty(result.Message) ? true : false;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = false;
            }

            return result;
        }

        public async Task<ResultReturned> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var result = new ResultReturned();
            try
            {

                result.Message = await _CustomerService.Update(request.Customer);
                result.Result = String.IsNullOrEmpty(result.Message) ? true : false;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = false;
            }

            return result;
        }

        public async Task<ResultReturned> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            var result = new ResultReturned();
            try
            {
                result.Message = "";
                await _CustomerService.Remove((long)request.Id);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
