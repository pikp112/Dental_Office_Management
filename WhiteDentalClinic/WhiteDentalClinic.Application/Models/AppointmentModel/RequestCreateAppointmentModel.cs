using System.ComponentModel.DataAnnotations;

namespace WhiteDentalClinic.Application.Models.AppointmentModel
{
    public class RequestCreateAppointmentModel
    {
        public Guid Id = Guid.NewGuid();
        public DateTime? DateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DentistId { get; set; }
        public Guid MedicalServiceId { get; set; }
    }
}