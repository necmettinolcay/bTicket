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
    public class PnrSearchController : Controller
    {
        private readonly ILogger<PnrSearchController> _logger;
        private readonly IPnrSearchViewModelService _pnrSearchViewModelService;


        public PnrSearchController(ILogger<PnrSearchController> logger, IPnrSearchViewModelService pnrSearchViewModelService)
        {
            _logger = logger;
            _pnrSearchViewModelService = pnrSearchViewModelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(string pnr)
        {
            var pnrSearchViewModel = _pnrSearchViewModelService.GetPnr(pnr);

            return View(pnrSearchViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
