using WhiteDentalClinic.Application.Models.Dentist;

namespace WhiteDentalClinic.Application.Services.Interfaces
{
    public interface IDentistService
    {
        IEnumerable<DentistResponseModel> GetAllDentists();
        DentistResponseModel GetDentistById(Guid id);
        DentistResponseModel CreateDentist(CreateDentistRequestModel requestDentistModel);
        UpdateDentistResponseModel UpdateDentist(Guid id, UpdateDentistRequestModel updateDentistModel);
        DentistResponseModel DeleteDentist(Guid id);
    }
}
