using AppointmentApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace  AppointmentApi.Buisness
{
    public interface IAppointmentBL 
    {
        public List<Appointment> GetAppointments(Guid? id,AppointmentDateRequest? appointmentDateRequest);

        public bool DeleteAppointment(Guid id);

        public string CreateAppointment(AppointmentRequest appointmentrequest);
    }
}