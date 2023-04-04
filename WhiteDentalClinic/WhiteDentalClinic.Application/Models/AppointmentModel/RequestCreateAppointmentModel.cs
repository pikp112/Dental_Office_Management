namespace WhiteDentalClinic.Application.Models.AppointmentModel
{
    public class RequestCreateAppointmentModel
    {
        public Guid Id { get; set; }
        public DateTime? dateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DentistId { get; set; }
    }
}