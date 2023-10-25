using FluentValidation;
using AppointmentApi.Models;

namespace appoinment.Validators
{
    public class AppointmentDateRequestValidator : AbstractValidator<AppointmentDateRequest>
    {
        public AppointmentDateRequestValidator(){
         
          RuleFor(appointmentDateRequest => appointmentDateRequest.Date)
          .NotEmpty()
          .Must(BeAValidDate)
          .WithMessage("Date must be in a valid format DD/MM/YYYY.");
        
        }
        private bool BeAValidDate(DateOnly date)
          {
             return (date != DateOnly.MinValue) || (date != DateOnly.MaxValue);
          }
    }
}