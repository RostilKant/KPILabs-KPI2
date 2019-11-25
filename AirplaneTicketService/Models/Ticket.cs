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
        [Required]
        public string Status { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public uint Price { get; set; }
        public string Class { get; set; }
        public int BagsCount { get; set; }
        [Required]
        public int Row { get; set; }
        [Required]
        public int Column { get; set; }
    }

   
}
