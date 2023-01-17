using BusTicket.Data.Entities;
using BusTicket.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Web.Interfaces
{
    public interface IPnrSearchViewModelService
    {
        PnrSearchViewModel GetPnr(string pnr);

    }
}
