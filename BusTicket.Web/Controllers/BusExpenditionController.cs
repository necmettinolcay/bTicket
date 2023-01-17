using BusTicket.Web.Interfaces;
using BusTicket.Web.Models;
using BusTicket.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Web.Controllers
{
    public class BusExpenditionController : Controller
    {
        private readonly ILogger<BusExpenditionController> _logger;
        private readonly IBusExpeditionViewModelService _busExpeditionViewModelService;


        public BusExpenditionController(ILogger<BusExpenditionController> logger, IBusExpeditionViewModelService busExpeditionViewModelService)
        {
            _logger = logger;
            _busExpeditionViewModelService = busExpeditionViewModelService;
        }

        public async Task<IActionResult> Expendition(string fromIdRoadPoint, string toIdRoadPoint, DateTime travelDate)
        {
            var busExpeditions = await _busExpeditionViewModelService.GetBusExpeditionAsync(fromIdRoadPoint, toIdRoadPoint, travelDate);

            return View(busExpeditions);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
