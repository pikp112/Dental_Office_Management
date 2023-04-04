using AutoMapper;
using WhiteDentalClinic.Application.Models.AppointmentModel;
using WhiteDentalClinic.Application.Services.Interfaces;
using WhiteDentalClinic.DataAccess.Entities;
using WhiteDentalClinic.DataAccess.Repositories.IRepositories;

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


        public IEnumerable<ResponseAppointmentModel> GelAll()
        {
            var allAppointments = _appointmentRepository.GetAll();
            return _mapper.Map<IEnumerable<ResponseAppointmentModel>>(allAppointments);
        }


        public IEnumerable<ResponseAppointmentModel> GetAllByCustomer(Guid customerRequestId)
        {
            var selectedAppointmentByCustomerId = _appointmentRepository.GetAll().Where(app => app.CustomerId == customerRequestId);

            return _mapper.Map<IEnumerable<ResponseAppointmentModel>>(selectedAppointmentByCustomerId);
        }


        public IEnumerable<ResponseAppointmentModel> GetAllByDentist(Guid dentistRequestId)
        {
            var selectedAppointmentByDentistId = _appointmentRepository.GetAll().Where(app => app.DentistId == dentistRequestId);

            return _mapper.Map<IEnumerable<ResponseAppointmentModel>>(selectedAppointmentByDentistId);
        }


        public ResponseAppointmentModel GetById(Guid appointmentId)
        {
            var selectedAppointmentById = _appointmentRepository.GetAll().FirstOrDefault(app => app.Id == appointmentId);
            return _mapper.Map<ResponseAppointmentModel>(selectedAppointmentById);
        }


        public ResponseAppointmentModel Create(RequestCreateAppointmentModel requestAppointmentModel)
        {
            var newAppointment = _mapper.Map<Appointment>(requestAppointmentModel);

            _appointmentRepository.AddEntity(newAppointment);

            return _mapper.Map<ResponseAppointmentModel>(newAppointment);
        }



        public ResponseAppointmentModel Delete(Guid appointmentId)
        {
            var selectedAppointmentById = _appointmentRepository.GetAll().FirstOrDefault(app => app.Id == appointmentId);

            _appointmentRepository.DeleteEntity(selectedAppointmentById);

            return _mapper.Map<ResponseAppointmentModel>(selectedAppointmentById);
        }



        public IEnumerable<DateTime> GetAvailableTimeSlots(DateTime date, int durationInMinutes)
        {
            // Get all appointments for the specified date
            var existingAppointments = _appointmentRepository
                .GetAll()
                .Where(a => a.DateTime == date)
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
                    if (currentSlot >= appointment.DateTime && currentSlot < appointment.DateTime)
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
