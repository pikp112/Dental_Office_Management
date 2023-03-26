using WhiteDentalClinic.DataAccess.Entities;
using WhiteDentalClinic.DataAccess.Repositories.IRepositories;

namespace WhiteDentalClinic.DataAccess.Repositories
{
    public class DentistServiceRepositoryBase : BaseRepository<DentistServiceEntity>, IDentistServiceRepository
    {
        public DentistServiceRepositoryBase(ApiDbTempContext context) : base(context)
        { }
    }
}
