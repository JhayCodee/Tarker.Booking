using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Api;
using Tarker.Booking.Common;
using Tarker.Booking.Application.Interfaces;
using Tarker.Booking.Application;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;
using Tarker.Booking.Persistence.DataBase;

// Creamos una instancia del constructor de la aplicación, que configura y construye la aplicación web.
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddCommon()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);


// Construimos la aplicación, preparando todos los servicios y configuraciones necesarios.
var app = builder.Build();


// Configuramos el pipeline de solicitudes HTTP y comenzamos a escuchar solicitudes entrantes.
app.Run();
