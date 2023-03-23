using WhiteDentalClinic.DataAccess.Entities;
using WhiteDentalClinic.DataAccess.Repositories.BaseRepositories;

namespace WhiteDentalClinic.DataAccess.Repositories.DentistServiceRepository
{
    public class DentistServiceRepositoryBase : BaseRepository<DentistServiceEntity>, IDentistServiceRepository
    {
        public DentistServiceRepositoryBase(ApiDbTempContext context) : base(context)
        { }
    }
}
