using Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBookings;

namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingsByType
{
    public interface IGetBookingsByTypeQuery
    {
        Task<List<GetAllBookingsModel>> Execute(string type);
    }
}
