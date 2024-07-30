using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.DataBasse;

namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBookings
{
    public class GetAllBookingsQuery : IGetAllBookingsQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllBookingsQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetAllBookingsModel>> Execute()
        {
            var result = await (from booking in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer 
                                on booking.CustomerId equals customer.CustomerId
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
