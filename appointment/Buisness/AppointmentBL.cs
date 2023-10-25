using apointment.Validators;
using appoinment.Validators;
using AppointmentApi.DataAccess;
using AppointmentApi.Models;
namespace AppointmentApi.Buisness
{
   public class AppointmentBL:IAppointmentBL
   {
      private readonly IAppointmentDL _appointmentDL;

      public AppointmentBL(IAppointmentDL appointmentDL)
      {
        _appointmentDL = appointmentDL;
      }
      
      // This function fetches appointment by date
      public List<Appointment> GetAppointments(Guid? id,AppointmentDateRequest? appointmentDateRequest) {
            AppointmentDateRequestValidator validator = new AppointmentDateRequestValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(appointmentDateRequest);
            // if (!result.IsValid)
            // {
            //     CustomError error = new CustomError(){Message = "Please Enter the date format in DD/MM/YYYY"};
            // }
            return _appointmentDL.GetAppointments(null,appointmentDateRequest.Date).OrderBy(app => app.StartTime).ToList();
     }


      //Funtion to create appointment
      public string CreateAppointment(AppointmentRequest appointmentrequest){
                

                //checking appointment with validator
                AppointmentRequestValidator validator = new AppointmentRequestValidator();
                FluentValidation.Results.ValidationResult results = validator.Validate(appointmentrequest);

                if (!results.IsValid)
                { 
                    string endTime = "greater";
                    foreach (var failure in results.Errors)
                    {
                        if(failure.ErrorMessage.IndexOf(endTime, StringComparison.CurrentCultureIgnoreCase) != -1)
                        {
                            return "End time must be greater than Start Time.";
                        }
                        if(failure.ErrorMessage.IndexOf("cannot have different dates", StringComparison.CurrentCultureIgnoreCase) != -1)
                        {
                            return "StartTime and EndTime cannot have different dates";
                        }
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                    return "Input Invalid";
                }

                // Convert the dto in main model object
                Appointment appointment = new Appointment
                {
                    StartTime = appointmentrequest.StartTime,
                    EndTime = appointmentrequest.EndTime,
                    Title = appointmentrequest.Title,
                    Id = Guid.NewGuid()
                };


                DateOnly dateOnly = new DateOnly(appointmentrequest.StartTime.Year, appointmentrequest.StartTime.Month, appointmentrequest.StartTime.Day);
 
                var appointments = _appointmentDL.GetAppointments(null,dateOnly);

                if (appointments.Any(item =>
                    item.StartTime < appointmentrequest.StartTime && item.EndTime > appointmentrequest.StartTime))
                    {
                        var conflictingAppointment = appointments.First(item =>
                            item.StartTime < appointmentrequest.StartTime && item.EndTime > appointmentrequest.StartTime);
                        var errorString = appointmentrequest.StartTime + " is conflicting with an existing appointment having startTime: " +
                            conflictingAppointment.StartTime + " and endTime: " + conflictingAppointment.EndTime;
                        return errorString;
                    }

                if (appointments.Any(item =>
                    appointmentrequest.EndTime > item.StartTime && appointmentrequest.EndTime < item.StartTime))
                    {
                        var conflictingAppointment = appointments.First(item =>
                            appointmentrequest.EndTime > item.StartTime && appointmentrequest.EndTime < item.StartTime);
                        var errorString = appointmentrequest.EndTime + " is conflicting with an existing appointment having startTime: " +
                            conflictingAppointment.StartTime + " and endTime: " + conflictingAppointment.EndTime;
                        return errorString;
                    }

                var stringId = _appointmentDL.CreateAppointment(appointment);

                return stringId.ToString();
            
      }

        //funtion to delete an appointment
        public bool DeleteAppointment(Guid id)
        { 
            var appointments  = _appointmentDL.GetAppointments(id,null);
            if(appointments.Count == 0)
            {
                return false;
            }
            _appointmentDL.DeleteAppointment(id);
            return true;
        }
    }
}