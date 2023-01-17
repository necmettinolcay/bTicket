using System;
using System.Collections.Generic;

#nullable disable

namespace BusTicket.Data.Entities
{
    public partial class Bus
    {
        public int IdBus { get; set; }
        public string Brand { get; set; }
        public string BusType { get; set; }
        public string Plate { get; set; }
        public int? Status { get; set; }
    }
}
