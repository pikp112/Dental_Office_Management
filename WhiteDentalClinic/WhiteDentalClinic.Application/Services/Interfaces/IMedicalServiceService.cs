using WhiteDentalClinic.Application.Models.MedicalServiceModel;

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
