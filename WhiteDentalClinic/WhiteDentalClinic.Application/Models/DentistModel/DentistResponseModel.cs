using System.ComponentModel.DataAnnotations;

namespace WhiteDentalClinic.Application.Models.Dentist
{
    public class DentistResponseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

    }
}