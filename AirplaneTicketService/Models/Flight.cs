using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneTicketService.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public Plane Plane { get; set; }
        public string ArriveAirport { get; set; }
        public string DepartureAirport { get; set; }
        public string DepartureGate { get; set; }
        public string Status { get; set; }
    }
        
    public class FlightDetails
    {
        public Flight Flight { get; set; }
        public string ArriveCountry { get; set; }
        public string ArriveCity { get; set; }
        public string DepartureCountry { get; set; }
        public string DepartureCity { get; set; }
        public string FirstPilot { get; set; }
        public string SecondPilot { get; set; }
    }
}
