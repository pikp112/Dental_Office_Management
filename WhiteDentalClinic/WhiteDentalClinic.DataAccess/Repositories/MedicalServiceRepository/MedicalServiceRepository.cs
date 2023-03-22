using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.DataAccess.Entities.MedicalServiceEntity;

namespace WhiteDentalClinic.DataAccess.Repositories.MedicalServiceRepository
{
    public class MedicalServiceRepository : BaseRepository<MedicalService>, IMedicalServiceRepository
    {
        public MedicalServiceRepository(ApiDbTempContext context) : base(context)
        {
        }
    }
}
