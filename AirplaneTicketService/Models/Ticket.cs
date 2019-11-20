using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneTicketService.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public Flight Flight { get; set; }
        public string Status { get; set; }
        [DataType(DataType.Currency)]
        public uint Price { get; set; }
    }

    public class TicketDetails
    {
        public Ticket Ticket { get; set; }
        public string Class { get; set; }
        public int BagsCount { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
