using System.ComponentModel.DataAnnotations;

namespace WhiteDentalClinic.Application.Models.UserModel
{
    public class CreateUserModel
    {
        public Guid Id = Guid.NewGuid();

        [StringLength(250, MinimumLength = 3, ErrorMessage = "Name should be minimum 3 characters and a maximum of 250 characters")]
        [DataType(DataType.Text)]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}