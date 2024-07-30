using Tarker.Booking.Api;
using Tarker.Booking.Application;
using Tarker.Booking.Common;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;

// Creamos una instancia del constructor de la aplicación, que configura y construye la aplicación web.
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddCommon()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers();

// Construimos la aplicación, preparando todos los servicios y configuraciones necesarios.
var app = builder.Build();
app.MapControllers();
app.Run();
