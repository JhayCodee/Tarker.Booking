using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBookings;
using Tarker.Booking.Application.DataBasse;

namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingsByDocumentNumber
{
    public class GetBookingsByDocumentNumberQuery : IGetBookingsByDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetBookingsByDocumentNumberQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _mapper = mapper;
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingsByDocumentNumberModel>> Execute(string documentNumber)
        {
            var result = await (from booking in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer
                                on booking.CustomerId equals customer.CustomerId
                                where customer.DocumentNumber == documentNumber
                                select new GetBookingsByDocumentNumberModel
                                {
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type,
                                }).ToListAsync();

            return result;
        }
    }
}
