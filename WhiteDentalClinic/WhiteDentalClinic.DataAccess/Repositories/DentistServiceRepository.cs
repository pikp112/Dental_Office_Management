using WhiteDentalClinic.DataAccess.Entities;
using WhiteDentalClinic.DataAccess.Repositories.IRepositories;

namespace WhiteDentalClinic.DataAccess.Repositories
{
    public class DentistServiceRepository : BaseRepository<DentistServiceEntity>, IDentistServiceRepository
    {
        public DentistServiceRepository(ApiDbTempContext context) : base(context)
        { }
    }
}
