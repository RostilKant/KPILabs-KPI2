using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Supplier2
{
    public class Flight
    {
        public int FlightId { get; set; }
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
        public List<Ticket> Tickets { get; set; }
    }
}
