using WhiteDentalClinic.DataAccess.Entities.CustomerEntity;
using WhiteDentalClinic.DataAccess.Repositories.BaseRepositories;

namespace WhiteDentalClinic.DataAccess.Repositories.CustomerRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    { }
}