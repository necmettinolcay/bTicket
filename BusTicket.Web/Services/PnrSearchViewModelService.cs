using BusTicket.Dal.Repositories;
using BusTicket.Data.Entities;
using BusTicket.Web.Extensions;
using BusTicket.Web.Interfaces;
using BusTicket.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusTicket.Web.Services
{
    public class PnrSearchViewModelService : IPnrSearchViewModelService
    {
        private readonly ILogger<PnrSearchViewModel> _logger;
        private readonly TicketRepository _ticketRepository;

        public PnrSearchViewModelService(ILoggerFactory loggerFactory, TicketRepository ticketRepository)
        {
            _logger = loggerFactory.CreateLogger<PnrSearchViewModel>();
            _ticketRepository = ticketRepository;
        }

        public PnrSearchViewModel GetPnr(string pnr)
        {
           _logger.LogInformation("GetPnr called.");

            var pnrSearchViewModel = new PnrSearchViewModel();
            pnrSearchViewModel.Ticket = _ticketRepository.GetByPnr(pnr);
            
            return pnrSearchViewModel;
        }
    }
}
