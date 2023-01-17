using BusTicket.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Web.Interfaces
{
    public interface IBusExpeditionViewModelService
    {
        Task<IEnumerable<BusExpeditionViewModel>> GetBusExpeditionAsync(string fromIdRoadPoint, string toIdRoadPoint, DateTime travelDate);

    }
}
