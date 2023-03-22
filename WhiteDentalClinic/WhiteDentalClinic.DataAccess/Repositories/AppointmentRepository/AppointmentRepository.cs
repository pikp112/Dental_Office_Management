using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.DataAccess.Entities.AppointmentEntity;

namespace WhiteDentalClinic.DataAccess.Repositories.AppointmentRepository
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApiDbTempContext context) : base(context)
        {
        }
    }
}
