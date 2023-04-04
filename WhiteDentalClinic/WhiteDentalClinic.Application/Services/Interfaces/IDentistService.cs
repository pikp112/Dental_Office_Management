using WhiteDentalClinic.Application.Models.Dentist;

namespace WhiteDentalClinic.Application.Services.Interfaces
{
    public interface IDentistService
    {
        IEnumerable<ResponseDentistModel> GetAll();
        ResponseDentistModel GetById(Guid id);
        ResponseDentistModel Create(RequestCreateDentistModel requestDentistModel);
        ResponseUpdateDentistModel Update(Guid id, RequestUpdateDentistModel updateDentistModel);
        ResponseDentistModel DeleteDentist(Guid id);
    }
}
