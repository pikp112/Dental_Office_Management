using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.Application.Models.AppointmentModel;
using WhiteDentalClinic.Application.Models.Dentist;
using WhiteDentalClinic.Application.Services;
using WhiteDentalClinic.DataAccess.Entities.AppointmentEntity;
using WhiteDentalClinic.DataAccess.Entities.DentistEntity;

namespace WhiteDentalClinic.Application.MappingProfiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile() 
        {
            CreateMap<Appointment, AppointmentResponseModel>();
            CreateMap<CreateAppointmentRequestModel, Appointment>();
        }
    }
}
