using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.Application.Models.MedicalServiceModel;
using WhiteDentalClinic.DataAccess.Entities.MedicalServiceEntity;

namespace WhiteDentalClinic.Application.Services.Interfaces
{
    public interface IMedicalServiceService
    {
        IEnumerable<ResponseMedicalServices> GetAllMedicalServices();
        ResponseMedicalServices CreateAMedicalService(CreateMedicalService requestMedicalServiceModel);
        IEnumerable<ResponseMedicalServices> GetAllMedicalServicesByDentistId(Guid requestDentistId);

        UpdateResponseMedicalService UpdateMedicalService(Guid id, UpdateRequestMedicalService updateMedicalServiceModel);
        ResponseMedicalServices DeleteMedicalService(Guid id);
    }
}
