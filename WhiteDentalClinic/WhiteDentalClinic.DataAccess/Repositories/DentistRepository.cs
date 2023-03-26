using WhiteDentalClinic.DataAccess.Entities;
using WhiteDentalClinic.DataAccess.Repositories.IRepositories;

namespace WhiteDentalClinic.DataAccess.Repositories
{
    public class DentistRepository : BaseRepository<Dentist>, IDentistRepository
    {
        public DentistRepository(ApiDbTempContext context) : base(context)
        {
        }
    }
}
