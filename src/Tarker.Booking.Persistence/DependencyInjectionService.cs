using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarker.Booking.Application.DataBasse;
using Tarker.Booking.Persistence.DataBase;

namespace Tarker.Booking.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            // Configuramos el contexto de la base de datos (DataBaseService) para usar SQL Server como proveedor de base de datos.
            // La cadena de conexión se obtiene de la configuración de la aplicación (appsettings.json o variables de entorno),
            // utilizando la clave "SQLConnectionString".
            services.AddDbContext<DataBaseService>(options => options.UseSqlServer(configuration["SQLConnectionString"]));

            // Registramos DataBaseService como una implementación de IDataBaseService en el contenedor de dependencias
            // con un ciclo de vida "scoped". Esto significa que una nueva instancia de DataBaseService será creada
            // para cada solicitud HTTP.
            services.AddScoped<IDataBaseService, DataBaseService>();

            return services;
        }
    }
}
