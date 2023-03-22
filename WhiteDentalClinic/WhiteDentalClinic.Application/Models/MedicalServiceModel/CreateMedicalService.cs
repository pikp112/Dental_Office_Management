using System.ComponentModel.DataAnnotations;

namespace WhiteDentalClinic.Application.Models.MedicalServiceModel
{
    public class CreateMedicalService
    {
        public Guid Id = Guid.NewGuid();

        [StringLength(250, MinimumLength = 3, ErrorMessage = "Name should be minimum 3 characters and a maximum of 250 characters")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Range(50, 10000, ErrorMessage = "Price cannot be less than 50 and more than 10000.")]
        public int Price { get; set; }

    }
}