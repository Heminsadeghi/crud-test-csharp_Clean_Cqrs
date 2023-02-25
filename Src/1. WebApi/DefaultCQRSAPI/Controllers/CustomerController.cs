using DefaultAPI.Application.Queries;
using DefaultAPI.Domain.Command;
using DefaultAPI.Domain.Dto;
using DefaultAPI.Domain.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultCQRSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CustomerController : BaseController
    {
        public CustomerController(ILogger<CustomerController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet("CustomerQueryId")]
        public async Task<IActionResult> GetById(long Id)
        {
            try
            {
                var response = await _mediator.Send(new CustomerQueryById(Id));
                if (response != null)
                    return Ok(response);

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        [HttpGet("CustomerQueryAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new CustomerQueryAll());
                if (response != null)
                    return Ok(response);

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        [HttpPost("CustomerQueryPage")]
        public async Task<IActionResult> GetByPage([FromBody] CustomerFilter CustomerFilter)
        {
            var response = await _mediator.Send(new CustomerQueryPage(CustomerFilter));
            if (response != null)
                return Ok(response);

            return BadRequest();
        }



        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CustomerAddDto CustomerSendDto)
        {
            var response = await _mediator.Send(new CustomerCreateCommand(CustomerSendDto));



            if (response != null && (bool)response.Result == true)
                return Ok(response);

            return BadRequest(response.Message);
        }


        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] CustomerEditDto CustomerSendDto)
        {


            var response = await _mediator.Send(new CustomerUpdateCommand(CustomerSendDto));
             if (response != null && (bool)response.Result == true)
                return Ok(response);

            return BadRequest(response.Message);
        }


        //[HttpPut("Update")]
        //public async Task<IActionResult> Update(int id, [FromBody] CustomerSendDto CustomerSendDto)
        //{
        //    if (!ModelState.IsValid) return CustomResponse(ModelState);

        //    Customer Customer = _mapperService.Map<Customer>(CustomerSendDto);

        //    if (id != CustomerSendDto.Id)
        //    {
        //        NotificationError(Constants.ErrorInGetId);
        //        return CustomResponse();
        //    }

        //    var result = await _CustomerService.Update(id, Customer);

        //    if (result)
        //        return NoContent();

        //    return CustomResponse();
        //}

        //[HttpDelete("Delete/{id:long}/{isDeletePhysical:bool}")]
        //public async Task<IActionResult> Delete(int id, bool isDeletePhysical = false)
        //{
        //    try
        //    {
        //        if (isDeletePhysical)
        //        {
        //            if (await _CustomerService.CanDelete(id))
        //            {
        //                bool result = await _CustomerService.DeletePhysical(id);
        //                if (result)
        //                    NotificationError(Constants.ErrorInDeletePhysical);
        //            }
        //        }
        //        else
        //        {
        //            bool result = await _CustomerService.DeleteLogic(id);
        //            if (result)
        //                NotificationError(Constants.ErrorInDeleteLogic);
        //        }

        //        return CustomResponse();
        //    }
        //    catch
        //    {
        //        if (isDeletePhysical && ProfileId == 1)
        //            NotificationError(Constants.ErrorInDeletePhysical);
        //        else if (isDeletePhysical && ProfileId != 1)
        //            NotificationError(Constants.NoAuthorization);
        //        else
        //            NotificationError(Constants.ErrorInDeleteLogic);

        //        return CustomResponse();
        //    }
        //}

    }
}
