namespace WhiteDentalClinic.DataAccess.Entities
{
    public class DentistServiceEntity : BaseEntity
    {
        public Guid DentistId { get; set; }
        public Dentist Dentist { get; set; }
        public Guid MedicalServiceId { get; set; }
        public MedicalService MedicalService { get; set; }
    }
}
