using AutoMapper;
using Tarker.Booking.Application.DataBase.Booking.Queries.GetAllBookings;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetAllCustomer;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber;
using Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserModel;
using Tarker.Booking.Application.DataBase.User.Queries.GetAllUser;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserById;
using Tarker.Booking.Application.DataBase.User.Queries.GetUserByUsernameAndPassword;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()      
        {
            #region User
            CreateMap<UserEnitity, CreateUserModel>().ReverseMap();
            CreateMap<UserEnitity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEnitity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEnitity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEnitity, GetUserByUsernameAndPasswordModel>().ReverseMap();
            #endregion

            #region Customer

            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, UpdateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByDocumentNumberModel>().ReverseMap();

            #endregion

            #region Booking

            CreateMap<BookingEntity, CreateCustomerModel>().ReverseMap();

            #endregion


        }
    }
}
