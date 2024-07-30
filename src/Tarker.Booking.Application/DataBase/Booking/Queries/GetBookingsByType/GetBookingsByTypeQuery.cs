using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBookings;
using Tarker.Booking.Application.DataBasse;

namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingsByType
{
    public class GetBookingsByTypeQuery : IGetBookingsByTypeQuery
    {
        private readonly IDataBaseService _dataBaseService;

        public GetBookingsByTypeQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetAllBookingsModel>> Execute(string type)
        {
            var result = await (from booking in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer
                                on booking.CustomerId equals customer.CustomerId
                                where booking.Type == type

                                select new GetAllBookingsModel
                                {
                                    BookingId = booking.BookingId,
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type,
                                    CustomerFullName = customer.FullName,
                                    CustomerDocumentNumber = customer.DocumentNumber,
                                }).ToListAsync();

            return result;
        }
    }
}
