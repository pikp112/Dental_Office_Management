using AutoMapper;
using WhiteDentalClinic.Application.Models.MedicalServiceModel;
using WhiteDentalClinic.DataAccess.Entities;

namespace WhiteDentalClinic.Application.MappingProfiles
{
    public class MedicalServiceProfile : Profile
    {
        public MedicalServiceProfile()
        {
            CreateMap<MedicalService, ResponseMedicalServices>();
            CreateMap<RequestCreateMedicalService,MedicalService>();
        }
    }
}
