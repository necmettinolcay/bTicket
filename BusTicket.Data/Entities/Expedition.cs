using System;
using System.Collections.Generic;

#nullable disable

namespace BusTicket.Data.Entities
{
    public partial class Expedition
    {
        public int IdExpedition { get; set; }
        public int? IdExpeditionType { get; set; }
        public DateTime? TravelDate { get; set; }
        public string ExpectedTravelTime { get; set; }
        public int? IdCompany { get; set; }
        public int? IdBus { get; set; }
        public int? Status { get; set; }
    }
}
