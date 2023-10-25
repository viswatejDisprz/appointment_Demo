using FluentValidation;
using AppointmentApi.Models;

namespace apointment.Validators
{
  public class AppointmentRequestValidator : AbstractValidator<AppointmentRequest>
      {
         public AppointmentRequestValidator()
         {

             // validate startTime for null and firmat
             RuleFor(appointment => appointment.StartTime)
             .NotEmpty()
             .Must(BeAValidDate)
             .WithMessage("Start Time must be a valid date and time.");

             // validate EndTime for null and firmat
             RuleFor(appointment => appointment.EndTime)
             .NotEmpty()
             .Must(BeAValidDate)
             .WithMessage("End Time must be a valid date and time.")
             .Must((appointmentRequest, endTime) => endTime > appointmentRequest.StartTime)
             .WithMessage("End time must be greater than Start Time.")
             .Must((AppointmentRequest,endTime) => endTime.Date == AppointmentRequest.StartTime.Date)
             .WithMessage("StartTime and EndTime cannot have different dates");

             // validate appointment title for null
             RuleFor(appointment => appointment.Title)
             .NotEmpty()
             .WithMessage("Appointment Title should not be empty");
         }

         // funciton to check format of time and also keep it in bounds
         private bool BeAValidDate(DateTime date)
          {
             return (date != DateTime.MinValue) || (date != DateTime.MaxValue);
          }
      }
}