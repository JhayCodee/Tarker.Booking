using Tarker.Booking.Api;
using Tarker.Booking.Common;
using Tarker.Booking.Application;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserModel;

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

app.MapPost("/testService", async (IUpdateUserCommand service) =>
{
    var model = new UpdateUserModel
    {
        UserId = 2,
        FirstName = "Jodue 2",
        LastName = "alala 2",
        UserName = "wqds2",
        Password = "01234",
    };

    return await service.Execute(model);
});

// Configuramos el pipeline de solicitudes HTTP y comenzamos a escuchar solicitudes entrantes.
app.Run();
