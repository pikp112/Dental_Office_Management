namespace WhiteDentalClinic.DataAccess.Entities
{
    public class Dentist : BaseEntity
    {
        public Dentist()
        {
            CreatedAt = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<DentistServiceEntity> dentistServices { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
