using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Web.Models
{
    public class BusExpeditionViewModel
    {
        public string IdBusExpedition { get; set; }
        public string IdCompany { get; set; }
        public string Company { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public string IdDeparturePoint { get; set; }
        public string DeparturePoint { get; set; }
        public string ArrivalPoint { get; set; }
        public string IdArrivalPoint { get; set; }
        public string TicketPrice { get; set; }
        public string Route { get; set; }
        public string BusExpeditionTypeDescription { get; set; }
        public string ExpectedTravelTime { get; set; }
    }
}
