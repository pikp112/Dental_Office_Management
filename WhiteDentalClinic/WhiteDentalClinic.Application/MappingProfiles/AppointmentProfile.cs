using AutoMapper;
using WhiteDentalClinic.Application.Models.AppointmentModel;
using WhiteDentalClinic.DataAccess.Entities;

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
