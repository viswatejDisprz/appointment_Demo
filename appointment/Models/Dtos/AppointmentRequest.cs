using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;
namespace AppointmentApi.Models
{
    public class  AppointmentRequest:ResponseDto
   {
        public DateTime StartTime {get; set;}

        public DateTime EndTime {get; set;}

        public string  Title {get; set;}
   }
}