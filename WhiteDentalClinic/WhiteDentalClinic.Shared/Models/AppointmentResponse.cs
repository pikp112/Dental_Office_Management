namespace WhiteDentalClinic.Shared.Models
{
    public class AppointmentResponse
    {
        public Guid Id { get; set; }
        public DateTime dateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DentistId { get; set; }
    }
}