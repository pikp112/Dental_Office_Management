using System.ComponentModel.DataAnnotations;

namespace WhiteDentalClinic.Application.Models.Customer
{
    public class RequestUpdateCustomerModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
    }
}