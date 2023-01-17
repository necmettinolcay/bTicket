using System;
using System.Collections.Generic;

#nullable disable

namespace BusTicket.Data.Entities
{
    public class ExpeditionType
    {
        public int IdExpeditionType { get; set; }
        public string ExpeditionTypeName { get; set; }
        public int? Status { get; set; }
    }
}
