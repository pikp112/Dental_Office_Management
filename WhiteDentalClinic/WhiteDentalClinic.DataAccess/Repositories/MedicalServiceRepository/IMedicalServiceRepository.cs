using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.DataAccess.Entities.DentistEntity;
using WhiteDentalClinic.DataAccess.Entities.MedicalServiceEntity;
using WhiteDentalClinic.DataAccess.Repositories.BaseRepositories;

namespace WhiteDentalClinic.DataAccess.Repositories.MedicalServiceRepository
{
    public interface IMedicalServiceRepository : IBaseRepository<MedicalService>
    { }
}
