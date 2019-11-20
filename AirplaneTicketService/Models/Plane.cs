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
}
