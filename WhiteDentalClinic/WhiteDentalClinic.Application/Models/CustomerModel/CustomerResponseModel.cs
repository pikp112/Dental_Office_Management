
using System.ComponentModel.DataAnnotations;
using WhiteDentalClinic.DataAccess.Entities.CustomerEntity;

namespace WhiteDentalClinic.Application.Models.Customer
{
    public class CustomerResponseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }       
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}


// toate api sa recurneze o clasa generica  iSucceseful(true/false) ori, ori Errors[], Result [], comuna la tot ce returneaza
