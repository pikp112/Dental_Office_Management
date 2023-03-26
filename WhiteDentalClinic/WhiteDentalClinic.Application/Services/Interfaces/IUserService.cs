using WhiteDentalClinic.Application.Models.UserModel;

namespace WhiteDentalClinic.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserResponseModel> CreateAsync(CreateUserModel createUserModel);

        // LoginAsync
        // ConfirmEmailAsync
        // ChangePasswordAsync
    }
}
