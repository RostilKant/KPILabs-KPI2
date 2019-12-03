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
        [Required]
        public string Country { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public uint NumOfSeats { get; set; }

        [DataType(DataType.Date)]
        public DateTime DayOfLastRepair { get; set; }

        public List<Flight> Flights { get; set; }
    }
    //public class Employee
    //{
    //    public Plane Plane { get; set; }

    //    [Required]
    //    public string FName { get; set; }

    //    [Required]
    //    public string LName { get; set; }

    //    [DataType(DataType.EmailAddress)]
    //    public string Email { get; set; }

    //    [Required]
    //    [DataType(DataType.PhoneNumber)]
    //    public string Phone { get; set; }
    //}
}
