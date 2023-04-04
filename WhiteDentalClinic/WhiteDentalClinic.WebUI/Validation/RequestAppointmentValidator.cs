using FluentValidation;
using WhiteDentalClinic.Shared.Models;

namespace WhiteDentalClinic.WebUI.Validation
{
    public class RequestAppointmentValidator:AbstractValidator<RequestAppointment>
    {
        public RequestAppointmentValidator() 
        {
/*            RuleFor(app => app.dateTime).NotEmpty().WithMessage("You must select a date and a time.")
                .GreaterThan(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Today.AddDays(1).Day))
                .WithMessage("You must select a day from tomorrow.");
            RuleFor(app => app.DentistId).NotEmpty().WithMessage("You must select a dentist.");
*/        }
    }
}
