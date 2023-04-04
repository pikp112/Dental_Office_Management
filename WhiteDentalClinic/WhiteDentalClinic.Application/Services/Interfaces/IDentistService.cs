using WhiteDentalClinic.Application.Models.Dentist;
using WhiteDentalClinic.Application.Models.MedicalServiceModel;

namespace WhiteDentalClinic.Application.Services.Interfaces
{
    public interface IDentistService
    {
        IEnumerable<ResponseDentistModel> GetAll();
        ResponseDentistModel GetById(Guid id);
        ResponseDentistModel Create(RequestCreateDentistModel requestDentistModel);
        ResponseUpdateDentistModel Update(Guid id, RequestUpdateDentistModel updateDentistModel);
        ResponseDentistModel DeleteDentist(Guid id);
        IEnumerable<ResponseMedicalServices> GetMedicalServicesByDentistId(Guid id);

    }
}
