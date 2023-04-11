namespace WhiteDentalClinic.Application.Models.Dentist
{
    public class RequestUpdateDentistModel
    {
        public string Email { get; set; }
        public Guid AdditionalMedicalServiceId { get; set; }
    }
}