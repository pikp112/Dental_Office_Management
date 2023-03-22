using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.DataAccess.Entities.DentistEntity;

namespace WhiteDentalClinic.DataAccess.Repositories.DentistRepository
{
    public class DentistRepository : BaseRepository<Dentist>, IDentistRepository
    {
        public DentistRepository(ApiDbTempContext context) : base(context)
        {
        }
    }
}
