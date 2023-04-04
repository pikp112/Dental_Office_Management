using AutoMapper;
using WhiteDentalClinic.Application.Models.Dentist;
using WhiteDentalClinic.DataAccess.Entities;

namespace WhiteDentalClinic.Application.MappingProfiles
{
    public class DentistProfile : Profile
    {
        public DentistProfile() 
        {
            CreateMap<Dentist, ResponseDentistModel>();
            CreateMap<RequestCreateDentistModel, Dentist>();
        }
    }
}
