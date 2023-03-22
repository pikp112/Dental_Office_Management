using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.Application.Models.MedicalServiceModel;
using WhiteDentalClinic.DataAccess.Entities.MedicalServiceEntity;

namespace WhiteDentalClinic.Application.MappingProfiles
{
    public class MedicalServiceProfile : Profile
    {
        public MedicalServiceProfile()
        {
            CreateMap<MedicalService, ResponseMedicalServices>();
            CreateMap<CreateMedicalService,MedicalService>();
        }
    }
}
