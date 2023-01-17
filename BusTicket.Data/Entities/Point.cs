using System;
using System.Collections.Generic;

#nullable disable

namespace BusTicket.Data.Entities
{
    public partial class Point
    {
        public int IdPoint { get; set; }
        public string PointName { get; set; }
        public int? IdConnectedPoint { get; set; }
        public int? Status { get; set; }
    }
}
