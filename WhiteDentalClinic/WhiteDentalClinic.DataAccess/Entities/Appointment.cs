namespace WhiteDentalClinic.DataAccess.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime? DateTime { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid DentistId { get; set; }
        public Dentist Dentist { get; set; }
        public MedicalService MedicalService { get; set; }
        public Guid MedicalServiceId { get; set; }
    }
}