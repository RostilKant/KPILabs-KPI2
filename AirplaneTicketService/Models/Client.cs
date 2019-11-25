using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneTicketService.Models
{
    public class Client
    {
        
        public int ClientId { get; set; }
        [Required]
        public string Passport { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
    public class Registration
    {
        public int RegistrationId { get; set; }
        public Client Client { get; set; }
        public Ticket Ticket { get; set; }

    }    
}
