using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
