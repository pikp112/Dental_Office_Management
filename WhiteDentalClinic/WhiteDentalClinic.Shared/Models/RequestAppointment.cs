
namespace WhiteDentalClinic.Shared.Models
{
    public class RequestAppointment
    {
        public Guid Id = Guid.NewGuid();
        public DateTime? dateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DentistId { get; set; }
        public Guid MedicalDentistId { get; set; }
    }
}
