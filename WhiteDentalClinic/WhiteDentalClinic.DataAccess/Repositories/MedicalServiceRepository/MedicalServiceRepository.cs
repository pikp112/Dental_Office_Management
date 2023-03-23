using WhiteDentalClinic.DataAccess.Entities;
using WhiteDentalClinic.DataAccess.Repositories.BaseRepositories;

namespace WhiteDentalClinic.DataAccess.Repositories.MedicalServiceRepository
{
    public class MedicalServiceRepository : BaseRepository<MedicalService>, IMedicalServiceRepository
    {
        public MedicalServiceRepository(ApiDbTempContext context) : base(context)
        {
        }
    }
}
