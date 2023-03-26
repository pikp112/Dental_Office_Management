namespace WhiteDentalClinic.DataAccess.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            CreatedAt = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
