using Tarker.Booking.Api;
using Tarker.Booking.Application;
using Tarker.Booking.Common;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;

// Creamos una instancia del constructor de la aplicaci�n, que configura y construye la aplicaci�n web.
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddCommon()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers();

// Construimos la aplicaci�n, preparando todos los servicios y configuraciones necesarios.
var app = builder.Build();
app.MapControllers();
app.Run();
