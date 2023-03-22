using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WhiteDentalClinic.Application.Models.AppointmentModel;
using WhiteDentalClinic.Application.Models.Dentist;
using WhiteDentalClinic.Application.Services.Interfaces;
using WhiteDentalClinic.DataAccess.Entities.AppointmentEntity;
using WhiteDentalClinic.DataAccess.Entities.DentistEntity;
using WhiteDentalClinic.DataAccess.Repositories.AppointmentRepository;

namespace WhiteDentalClinic.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository= appointmentRepository;
            _mapper= mapper;
        }
        public IEnumerable<AppointmentResponseModel> GetAllAppointments()
        {
            var allAppointments = _appointmentRepository.GetAll();
            return _mapper.Map<IEnumerable<AppointmentResponseModel>>(allAppointments);
        }
        public IEnumerable<AppointmentResponseModel> GetAllAppointmentsByCustomer(Guid customerRequestId)
        {
            var selectedAppointmentByCustomerId = _appointmentRepository.GetAll().Where(app => app.CustomerId == customerRequestId);

            return _mapper.Map<IEnumerable<AppointmentResponseModel>>(selectedAppointmentByCustomerId);
        }
        public IEnumerable<AppointmentResponseModel> GetAllAppointmentsByDentist(Guid dentistRequestId)
        {
            var selectedAppointmentByDentistId = _appointmentRepository.GetAll().Where(app => app.DentistId == dentistRequestId);

            return _mapper.Map<IEnumerable<AppointmentResponseModel>>(selectedAppointmentByDentistId);
        }

        public AppointmentResponseModel GetAppointmentById(Guid appointmentId)
        {
            var selectedAppointmentById = _appointmentRepository.GetAll().FirstOrDefault(app => app.Id == appointmentId);
            return _mapper.Map<AppointmentResponseModel>(selectedAppointmentById);
        }

        public AppointmentResponseModel CreateAppointment(CreateAppointmentRequestModel requestAppointmentModel)
        {
            var newAppointment = _mapper.Map<Appointment>(requestAppointmentModel);

            _appointmentRepository.AddEntity(newAppointment);

            return _mapper.Map<AppointmentResponseModel>(newAppointment);
        }

        public AppointmentResponseModel DeleteAppointment(Guid appointmentId)
        {
            var selectedAppointmentById = _appointmentRepository.GetAll().FirstOrDefault(app => app.Id == appointmentId);

            _appointmentRepository.DeleteEntity(selectedAppointmentById);

            return _mapper.Map<AppointmentResponseModel>(selectedAppointmentById);
        }

        public IEnumerable<DateTime> GetAvailableTimeSlots(DateTime date, int durationInMinutes)
        {
            // Get all appointments for the specified date
            var existingAppointments = _appointmentRepository
                .GetAll()
                .Where(a => a.dateTime == date)
                .ToList();

            // Calculate the available time slots based on the duration of each appointment
            var startOfDay = new DateTime(date.Year, date.Month, date.Day, 9, 0, 0);
            var endOfDay = new DateTime(date.Year, date.Month, date.Day, 17, 0, 0);
            var currentSlot = startOfDay;
            var availableSlots = new List<DateTime>();

            while (currentSlot + TimeSpan.FromMinutes(durationInMinutes) <= endOfDay)
            {
                // Check if the current time slot is available
                var isAvailable = true;
                foreach (var appointment in existingAppointments)
                {
                    if (currentSlot >= appointment.dateTime && currentSlot < appointment.dateTime)
                    {
                        isAvailable = false;
                        break;
                    }
                }

                // If the time slot is available, add it to the list
                if (isAvailable)
                {
                    availableSlots.Add(currentSlot);
                }

                // Move to the next time slot
                currentSlot += TimeSpan.FromMinutes(durationInMinutes);
            }

            return availableSlots;
        }
    }
}
