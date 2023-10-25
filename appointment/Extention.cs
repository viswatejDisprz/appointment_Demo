using System;
using System.Collections.Generic;
using AppointmentApi.DataAccess;
using AppointmentApi.Buisness;
using AppointmentApi.Models;
using appoinment.Eception;
using System.Net;

namespace AppointmentApi
{
    public static class Extensions
    {
        public static AppointmentRequest AsDto(this Appointment appointment)
        {
           return new AppointmentRequest
           {
               StartTime = appointment.StartTime,
               EndTime = appointment.EndTime,
               Title = appointment.Title,
           };
        }

        // public static HttpResponseException CustomException(this CustomError error, HttpStatusCode statusCode)
        // {
        //     var response = new HttpResponseMessage
        //     {
        //         Content = new StringContent(error.Message),
        //         StatusCode = statusCode
        //     };

        //     return new HttpResponseException(response);
        // }
    }
}