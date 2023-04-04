using WhiteDentalClinic.DataAccess.Entities;
using WhiteDentalClinic.DataAccess.Repositories.IRepositories;

namespace WhiteDentalClinic.DataAccess.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApiDbTempContext context) : base(context)
        {
        }
    }
}
