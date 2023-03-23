using WhiteDentalClinic.DataAccess.Entities;
using WhiteDentalClinic.DataAccess.Repositories.BaseRepositories;

namespace WhiteDentalClinic.DataAccess.Repositories.DentistRepository
{
    public class DentistRepository : BaseRepository<Dentist>, IDentistRepository
    {
        public DentistRepository(ApiDbTempContext context) : base(context)
        {
        }
    }
}
