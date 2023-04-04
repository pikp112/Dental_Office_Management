using AutoMapper;
using WhiteDentalClinic.Application.Models.Customer;
using WhiteDentalClinic.DataAccess.Entities;

namespace WhiteDentalClinic.Application.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<Customer, CustomerResponseModel>();
            CreateMap<CreateCustomerRequestModel, Customer>();

        }
    }
}
