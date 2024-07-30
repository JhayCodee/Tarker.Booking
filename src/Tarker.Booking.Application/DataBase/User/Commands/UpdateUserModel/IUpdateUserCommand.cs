
namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUserModel
{
    public interface IUpdateUserCommand
    {
        Task<UpdateUserModel> Execute(UpdateUserModel model);
    }
}
