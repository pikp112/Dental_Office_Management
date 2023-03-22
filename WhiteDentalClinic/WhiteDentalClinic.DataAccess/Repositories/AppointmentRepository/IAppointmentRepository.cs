using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.DataAccess.Entities.AppointmentEntity;
using WhiteDentalClinic.DataAccess.Repositories.BaseRepositories;

namespace WhiteDentalClinic.DataAccess.Repositories.AppointmentRepository
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
    }
}
