using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Persistence.DataBase;

// Creamos una instancia del constructor de la aplicaci�n, que configura y construye la aplicaci�n web.
var builder = WebApplication.CreateBuilder(args);

// Configuramos el contexto de la base de datos (DataBaseService) para usar SQL Server como proveedor de base de datos.
// La cadena de conexi�n se obtiene de la configuraci�n de la aplicaci�n (appsettings.json o variables de entorno),
// utilizando la clave "SQLConnectionString".
builder.Services.AddDbContext<DataBaseService>(options =>
    options.UseSqlServer(builder.Configuration["SQLConnectionString"]));

// Registramos DataBaseService como una implementaci�n de IDataBaseService en el contenedor de dependencias
// con un ciclo de vida "scoped". Esto significa que una nueva instancia de DataBaseService ser� creada
// para cada solicitud HTTP.
builder.Services.AddScoped<IDataBaseService, DataBaseService>();

// Construimos la aplicaci�n, preparando todos los servicios y configuraciones necesarios.
var app = builder.Build();

// Configuramos el pipeline de solicitudes HTTP y comenzamos a escuchar solicitudes entrantes.
app.Run();
