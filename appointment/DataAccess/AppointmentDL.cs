using AppointmentApi.DataAccess;
using AppointmentApi.Models;
namespace AppointmentApi.Buisness {
  public class AppointmentDL: IAppointmentDL {
    private List < Appointment > appointments = new() {
      new Appointment {
        StartTime = new DateTime(2023, 10, 15, 23, 00, 00), EndTime = new DateTime(2023, 10, 15, 23, 59, 00), Title = "go to Gym", Id = Guid.NewGuid()
      },
      new Appointment {
        StartTime = new DateTime(2023, 10, 15, 13, 00, 00), EndTime = new DateTime(2023, 10, 15, 13, 59, 00), Title = "go for a walk", Id = Guid.NewGuid()
      },
      new Appointment {
        StartTime = new DateTime(2023, 10, 15, 19, 00, 00), EndTime = new DateTime(2023, 10, 15, 19, 59, 00), Title = "go for cohee", Id = Guid.NewGuid()
      }
    };

    // This function fetches appointment by date
    public List < Appointment > GetAppointments(Guid ? id = null, DateOnly ? date = null) {

      // Filter appointments by date
      var condition = new Func<Appointment, bool>(app => date.HasValue ? DateOnly.FromDateTime(app.StartTime) == date : app.Id == id);
      return appointments.Where(condition).ToList();
    }

    //Funtion to create appointment
    public Guid CreateAppointment(Appointment appointment) {
      appointments.Add(appointment);
      return appointment.Id;

    }

    //funtion to delete an appointment
    public void DeleteAppointment(Guid id) {
      var index = appointments.FindIndex(existingItem => existingItem.Id == id);
      appointments.RemoveAt(index);
    }
  }
}