using BusTicket.Dal.Repositories;
using BusTicket.Data.Data;
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
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusTicket.Web.Services
{
    public class RoadPointViewModelService : IRoadPointViewModelService
    {
        private readonly ILogger<RoadPointViewModelService> _logger;

        public RoadPointViewModelService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<RoadPointViewModelService>();
        }

        public async Task<IEnumerable<RoadPointViewModel>> GetRoadPointsAsync()
        {
            
           _logger.LogInformation("GetRoadPointsAsync called.");

            var client = new oTicket.ServiceSoapClient(oTicket.ServiceSoapClient.EndpointConfiguration.ServiceSoap);
            var result = await client.XmlIsletAsync(XmlHelper.StrToXmlElement("<KaraNoktaGetirKomut/>"), XmlHelper.UserPasswordXmlElement());

            var items = XmlHelper.XmlNodeToDataset(result.Body.XmlIsletResult).Tables[0].AsEnumerable()
                .Select(row => new RoadPointViewModel() { 
                    IdRoadPoint = row.Field<string>("ID"),
                    PointName = row.Field<string>("Ad"),
                })
                .ToList();
          
            return items;
        }
    }
}
