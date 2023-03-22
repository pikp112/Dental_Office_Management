using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.Application.Models.Customer;
using WhiteDentalClinic.Application.Services;
using WhiteDentalClinic.DataAccess.Entities.CustomerEntity;

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
