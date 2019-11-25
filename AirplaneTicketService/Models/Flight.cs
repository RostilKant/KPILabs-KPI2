using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneTicketService.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public Plane Plane { get; set; }
        [Required]
        public string ArriveAirport { get; set; }
        [Required]
        public string DepartureAirport { get; set; }
        [Required]
        public string DepartureGate { get; set; }
        public string Status { get; set; }
        [Required]
        public string FirstPilot { get; set; }
        public string SecondPilot { get; set; }
    }
        
    //public class FlightDetails
    //{
    //    public Flight Flight { get; set; }
    //    [Required]
    //    public string ArriveCountry { get; set; }
    //    [Required]
    //    public string ArriveCity { get; set; }
    //    [Required]
    //    public string DepartureCountry { get; set; }
    //    [Required]
    //    public string DepartureCity { get; set; }
    //    [Required]
    //    public string FirstPilot { get; set; }
    //    public string SecondPilot { get; set; }
    //}
}
