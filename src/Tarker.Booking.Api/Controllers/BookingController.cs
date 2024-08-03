using Microsoft.AspNetCore.Mvc;
using Tarker.Booking.Application.DataBase.Booking.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBookings;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingsByDocumentNumber;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingsByType;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/booking")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create (
            [FromBody] CreateBookingModel model,
            [FromServices] ICreateBookingCommand createBookingCommand
        )
        {
            var data = await createBookingCommand.Execute(model);

            return Ok(ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult>GetAll(
            [FromServices] IGetAllBookingsQuery getAllBookingsQuery
        )
        {
            var data = await getAllBookingsQuery.Execute();

            if (data.Count == 0)
                return NotFound(ResponseApiService.Response(StatusCodes.Status404NotFound));

            return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-type/{type}")]
        public async Task<IActionResult> GetByType(
            string type,
            [FromServices] IGetBookingsByTypeQuery getBookingsByTypeQuery
        )
        {
            if (string.IsNullOrEmpty(type))
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getBookingsByTypeQuery.Execute(type);

            if (data == null)
                return NotFound(ResponseApiService.Response(StatusCodes.Status404NotFound));

            return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-document-number")]
        public async Task<IActionResult> GetByDocumentNumber(
            [FromQuery] string documentNumber,
            [FromServices] IGetBookingsByDocumentNumberQuery getBookingsByDocumentNumberQuery
        )
        {
            if (string.IsNullOrEmpty(documentNumber))
                return BadRequest(ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getBookingsByDocumentNumberQuery.Execute(documentNumber);

            if (data == null)
                return NotFound(ResponseApiService.Response(StatusCodes.Status404NotFound));

            return Ok(ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
