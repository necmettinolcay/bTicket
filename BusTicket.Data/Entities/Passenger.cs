using System;
using System.Collections.Generic;

#nullable disable

namespace BusTicket.Data.Entities
{
    public partial class Passenger
    {
        public int IdPassenger { get; set; }
        public string PassengerName { get; set; }
        public string PassengerIdentity { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Gender { get; set; }
        public int? Status { get; set; }
    }
}
