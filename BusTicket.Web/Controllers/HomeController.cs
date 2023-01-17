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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoadPointViewModelService _roadPointViewModelService;


        public HomeController(ILogger<HomeController> logger, IRoadPointViewModelService roadPointViewModelService)
        {
            _logger = logger;
            _roadPointViewModelService = roadPointViewModelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string fromIdRoadPoint, string toIdRoadPoint, DateTime travelDate)
        {
            return RedirectToAction("Expendition", "BusExpendition", new { 
                @fromIdRoadPoint = fromIdRoadPoint,
                @toIdRoadPoint = toIdRoadPoint,
                @travelDate = travelDate
            });
        }

        [HttpPost]
        public async Task<JsonResult> AutoCompleteAsync(string prefix)
        {
            var points = await _roadPointViewModelService.GetRoadPointsAsync();

            var matchedPoint = (from point in points
                             where point.PointName.StartsWith(prefix)
                             select new
                             {
                                 label = point.PointName,
                                 val = point.IdRoadPoint
                             }).ToList();

            return Json(matchedPoint);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
