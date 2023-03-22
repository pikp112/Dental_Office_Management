using WhiteDentalClinic.DataAccess.Entities.AppointmentEntity;
using WhiteDentalClinic.DataAccess.Entities.CommonEntities;

namespace WhiteDentalClinic.DataAccess.Entities.CustomerEntity
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            CreatedAt = DateTime.Now;
            Role = Role.Customer;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public override Role Role { get; }
        public DateTime CreatedAt { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
