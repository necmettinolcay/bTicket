using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Web.Models
{
    public class RoadPointModel
    {
        public string IdRoadPoint { get; set; }
        public string IdTravelCity { get; set; }
        public string Region { get; set; }
        public string PointName { get; set; }
        public string Description { get; set; }
        public string IsCenter { get; set; }
        public string IdConnectedPoint { get; set; }
    }
}