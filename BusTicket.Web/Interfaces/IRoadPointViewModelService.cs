using BusTicket.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Web.Interfaces
{
    public interface IRoadPointViewModelService
    {
        Task<IEnumerable<RoadPointViewModel>> GetRoadPointsAsync();
    }
}
