using WhiteDentalClinic.Application.Models.UserModel;

namespace WhiteDentalClinic.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseCreateUserModel> CreateAsync(RequestCreateUserModel createUserModel);

        // LoginAsync
        // ConfirmEmailAsync
        // ChangePasswordAsync
    }
}
