namespace WhiteDentalClinic.Application.Models.AppointmentModel
{
    public class ResponseAppointmentModel
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DentistId { get; set; }
        public Guid MedicalServiceId { get; set; }

    }
}