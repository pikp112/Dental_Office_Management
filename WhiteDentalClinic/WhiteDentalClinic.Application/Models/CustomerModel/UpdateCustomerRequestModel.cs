using System.ComponentModel.DataAnnotations;

namespace WhiteDentalClinic.Application.Models.Customer
{
    public class UpdateCustomerRequestModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
    }
}