using WhiteDentalClinic.Application.Models.AppointmentModel;

namespace WhiteDentalClinic.Application.Services.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<ResponseAppointmentModel> GelAll();
        IEnumerable<ResponseAppointmentModel> GetAllByCustomer(Guid customerRequestId);
        IEnumerable<ResponseAppointmentModel> GetAllByDentist(Guid dentistRequestId);
        ResponseAppointmentModel GetById(Guid appointmentId);
        List<DateTime> CheckAppointments(DateTime date, Guid dentistId);
        ResponseAppointmentModel Create(RequestCreateAppointmentModel requestAppointmentModel);
        ResponseAppointmentModel Delete(Guid appointmentId);
        IEnumerable<DateTime> GetAvailableTimeSlots(DateTime date, int durationInMinutes);
    }
}
