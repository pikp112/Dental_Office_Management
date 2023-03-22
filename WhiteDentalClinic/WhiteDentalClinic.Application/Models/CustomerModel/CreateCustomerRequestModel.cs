using System.ComponentModel.DataAnnotations;

namespace WhiteDentalClinic.Application.Models.Customer
{
    public class CreateCustomerRequestModel
    {
        public Guid Id = Guid.NewGuid();
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Range(16,110, ErrorMessage = "Age cannot be less than 16 and more than 110.")]
        public int Age { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}