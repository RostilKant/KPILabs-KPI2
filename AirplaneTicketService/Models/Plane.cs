using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneTicketService.Models
{
    public class Plane
    {
        public int PlaneId { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public uint NumOfSeats { get; set; }

        [DataType(DataType.Date)]
        public DateTime DayOfLastRepair { get; set; }
    }
    public class Employee
    {
        public Plane Plane { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
