using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateCustomerModel model,
            [FromServices] ICreateCustomerCommand createCustomerCommand
        )
        {
            var data = await createCustomerCommand.Execute(model);

            return StatusCode(
                StatusCodes.Status201Created,
                ResponseApiService.Response(StatusCodes.Status201Created, data)
            );
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateCustomerModel model,
            [FromServices] IUpdateCustomerCommand updateCustomerCommand
        )
        {
            var data = await updateCustomerCommand.Execute(model);

            return StatusCode(
                StatusCodes.Status200OK,
                ResponseApiService.Response(StatusCodes.Status200OK, data)
            );
        }

        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete(
            int customerId,
            [FromServices] IDeleteCustomerCommand deleteCustomerCommand
        )
        {
            if (customerId == 0)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var result = await deleteCustomerCommand.Execute(customerId);

            if (!result)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllCustomerQuery getAllCustomerQuery
        )
        {
            var list = await getAllCustomerQuery.Execute();

            if (list.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, list));
        }

        [HttpGet("get-customer-by-id/{customerId}")]
        public async Task<IActionResult> GetCustomerById(
            int customerId,
            [FromServices] IGetCustomerByIdQuery getCustomerByIdQuery
        )
        {
            if (customerId <= 0)
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getCustomerByIdQuery.Execute(customerId);

            if (data == null)
                return NotFound(ResponseApiService.Response(StatusCodes.Status404NotFound)); 

            return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-customer-by-documentnumber/{documentNumber}")]
        public async Task<IActionResult> GetCustomerByDocumentNumber(
            string documentNumber,
            [FromServices] IGetCustomerByDocumentNumberQuery getCustomerByDocumentNumberQuery
        )
        {
            if(string.IsNullOrEmpty(documentNumber))
                return NotFound(ResponseApiService.Response(StatusCodes.Status404NotFound));

            var data = await getCustomerByDocumentNumberQuery.Execute(documentNumber);

            if (data == null)
                return NotFound(ResponseApiService.Response(StatusCodes.Status404NotFound));

            return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

    }
}
