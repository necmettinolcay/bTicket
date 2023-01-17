using System;
using System.Collections.Generic;

#nullable disable

namespace BusTicket.Data.Entities
{
    public partial class Ticket
    {
        public int IdTicket { get; set; }
        public string Pnr { get; set; }
        public int? IdPassenger { get; set; }
        public int? IdExpedition { get; set; }
        public int? IdChair { get; set; }
        public int? ServiceRequest { get; set; }
        public int? EticketNo { get; set; }
        public int? IdDeparturePoint { get; set; }
        public int? IdArrivalPoint { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }
    }
}
