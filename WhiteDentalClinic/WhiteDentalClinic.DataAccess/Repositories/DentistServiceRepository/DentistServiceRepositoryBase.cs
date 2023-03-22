using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.DataAccess.Entities.CustomerEntity;
using WhiteDentalClinic.DataAccess.Entities.ServiceDentist;
using WhiteDentalClinic.DataAccess.Repositories.CustomerRepository;

namespace WhiteDentalClinic.DataAccess.Repositories.DentistServiceRepository
{
    public class DentistServiceRepositoryBase : BaseRepository<DentistServiceEntity>, IDentistServiceRepository
    {
        public DentistServiceRepositoryBase(ApiDbTempContext context) : base(context)
        { }
    }
}
