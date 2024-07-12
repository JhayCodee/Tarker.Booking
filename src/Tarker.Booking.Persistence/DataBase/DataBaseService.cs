using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;
using Tarker.Booking.Persistence.Configuration;

namespace Tarker.Booking.Persistence.DataBase
{
    // Esta clase representa el servicio de acceso a la base de datos y hereda de DbContext, que es parte de Entity Framework Core.
    public class DataBaseService : DbContext, IDataBaseService
    {
        // Constructor que recibe opciones de configuración para el contexto de base de datos y las pasa a la clase base.
        public DataBaseService(DbContextOptions options) : base(options)
        {

        }

        // DbSet representa una colección de todas las entidades en el contexto o que se pueden consultar desde la base de datos.
        public DbSet<UserEnitity> User { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<BookingEntity> Booking { get; set; }

        // Método asincrónico para guardar los cambios en la base de datos. Devuelve true si los cambios fueron guardados correctamente.
        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        // Método protegido que se llama cuando se está creando el modelo de datos.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        // Método privado para configurar las entidades usando clases de configuración específicas.
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<UserEnitity>());
            new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
            new BookingConfiguration(modelBuilder.Entity<BookingEntity>());
        }
    }
}
