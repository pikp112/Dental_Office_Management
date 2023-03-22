using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WhiteDentalClinic.DataAccess.Entities.CustomerEntity;
using WhiteDentalClinic.DataAccess.Entities.DentistEntity;

namespace WhiteDentalClinic.DataAccess.Entities.AppointmentEntity
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime? dateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid DentistId { get; set; }
        public Dentist Dentist { get; set; }
    }
}