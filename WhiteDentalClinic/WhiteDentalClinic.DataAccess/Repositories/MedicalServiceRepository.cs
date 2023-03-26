using WhiteDentalClinic.DataAccess.Entities;
using WhiteDentalClinic.DataAccess.Repositories.IRepositories;

namespace WhiteDentalClinic.DataAccess.Repositories
{
    public class MedicalServiceRepository : BaseRepository<MedicalService>, IMedicalServiceRepository
    {
        public MedicalServiceRepository(ApiDbTempContext context) : base(context)
        {
        }
    }
}
