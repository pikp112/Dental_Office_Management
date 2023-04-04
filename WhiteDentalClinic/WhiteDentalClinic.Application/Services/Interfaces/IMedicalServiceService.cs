using WhiteDentalClinic.Application.Models.MedicalServiceModel;

namespace WhiteDentalClinic.Application.Services.Interfaces
{
    public interface IMedicalServiceService
    {
        IEnumerable<ResponseMedicalServices> GetAll();
        ResponseMedicalServices Create(RequestCreateMedicalService requestMedicalServiceModel);
        IEnumerable<ResponseMedicalServices> GetAllByDentistId(Guid requestDentistId);

        ResponseUpdateMedicalService Update(Guid id, RequestUpdateMedicalService updateMedicalServiceModel);
        ResponseMedicalServices Delete(Guid id);
    }
}
