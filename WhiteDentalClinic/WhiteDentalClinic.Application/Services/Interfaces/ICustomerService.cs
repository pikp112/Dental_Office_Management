using WhiteDentalClinic.Application.Models.Customer;

namespace WhiteDentalClinic.Application.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerResponseModel> GetAllCustomers();
        CustomerResponseModel GetCustomerById(Guid id);
        CustomerResponseModel CreateCustomer(CreateCustomerRequestModel requestCustomerModel);
        UpdateCustomerResponseModel UpdateCustomer(Guid id, UpdateCustomerRequestModel updateCustomerModel);
        CustomerResponseModel DeleteCustomer(Guid id);
    }
}
