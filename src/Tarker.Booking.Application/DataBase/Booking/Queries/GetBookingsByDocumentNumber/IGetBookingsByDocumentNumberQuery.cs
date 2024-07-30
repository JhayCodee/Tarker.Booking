using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Booking.Queries.GetBookingsByDocumentNumber
{
    public interface IGetBookingsByDocumentNumberQuery
    {
        Task<List<GetBookingsByDocumentNumberModel>> Execute(string documentNumber);
    }
}
