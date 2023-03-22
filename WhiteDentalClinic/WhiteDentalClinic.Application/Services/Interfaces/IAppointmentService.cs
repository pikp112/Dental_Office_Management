using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteDentalClinic.Application.Models.AppointmentModel;
using WhiteDentalClinic.Application.Models.Dentist;

namespace WhiteDentalClinic.Application.Services.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentResponseModel> GetAllAppointments();
        IEnumerable<AppointmentResponseModel> GetAllAppointmentsByCustomer(Guid customerRequestId);
        IEnumerable<AppointmentResponseModel> GetAllAppointmentsByDentist(Guid dentistRequestId);
        AppointmentResponseModel GetAppointmentById(Guid appointmentId);
        AppointmentResponseModel CreateAppointment(CreateAppointmentRequestModel requestAppointmentModel);
        AppointmentResponseModel DeleteAppointment(Guid appointmentId);
        IEnumerable<DateTime> GetAvailableTimeSlots(DateTime date, int durationInMinutes);
    }
}
