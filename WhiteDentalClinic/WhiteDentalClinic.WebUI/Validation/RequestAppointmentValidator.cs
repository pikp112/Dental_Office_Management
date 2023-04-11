using FluentValidation;
using WhiteDentalClinic.Shared.Models;

namespace WhiteDentalClinic.WebUI.Validation
{
    public class RequestAppointmentValidator:AbstractValidator<RequestAppointment>
    {
        public RequestAppointmentValidator() 
        {
            RuleFor(app => app.DentistId).NotEmpty().WithMessage("You must select a dentist.");
            RuleFor(app => app.MedicalServiceId).NotEmpty().WithMessage("You must select a medical service.");
        }
    }
}
