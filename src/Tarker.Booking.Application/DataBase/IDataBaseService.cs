using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.DataBasse
{
    public interface IDataBaseService
    {
        public DbSet<UserEnitity> User { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<BookingEntity> Booking { get; set; }

        public Task<bool> SaveAsync();
    }
}
