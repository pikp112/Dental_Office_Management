using WhiteDentalClinic.Application.Models.Customer;

namespace WhiteDentalClinic.Application.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<ResponseCustomerModel> GetAll();
        ResponseCustomerModel GetById(Guid id);
        ResponseCustomerModel Create(RequestCreateCustomerModel requestCustomerModel);
        ResponseUpdateCustomerModel Update(Guid id, RequestUpdateCustomerModel updateCustomerModel);
        ResponseCustomerModel Delete(Guid id);
    }
}
