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
    public class BusExpeditionViewModelService : IBusExpeditionViewModelService
    {
        private readonly ILogger<BusExpeditionViewModelService> _logger;

        public BusExpeditionViewModelService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BusExpeditionViewModelService>();
        }

        public async Task<IEnumerable<BusExpeditionViewModel>> GetBusExpeditionAsync(string fromIdRoadPoint, string toIdRoadPoint, DateTime travelDate)
        {
           _logger.LogInformation("GetRoadPointsAsync called.");

            var xmlStr = CreateBusExpeditionXml(fromIdRoadPoint, toIdRoadPoint, travelDate);
            var client = new oTicket.ServiceSoapClient(oTicket.ServiceSoapClient.EndpointConfiguration.ServiceSoap);
            var result = await client.XmlIsletAsync(XmlHelper.StrToXmlElement(xmlStr), XmlHelper.UserPasswordXmlElement());

            var items = XmlHelper.XmlNodeToDataset(result.Body.XmlIsletResult).Tables[0].AsEnumerable()
                .Select(row => new BusExpeditionViewModel() { 
                    IdBusExpedition = row.Field<string>("ID"),
                    IdCompany = row.Field<string>("FirmaNo"),
                    Company = row.Field<string>("FirmaAdi"),
                    DepartureDate = row.Field<string>("Tarih"),
                    DepartureTime = row.Field<string>("Saat"),
                    IdDeparturePoint = row.Field<string>("KalkisNoktaID"),
                    DeparturePoint = row.Field<string>("KalkisNokta"),
                    IdArrivalPoint = row.Field<string>("VarisNoktaID"),
                    ArrivalPoint = row.Field<string>("VarisNokta"),
                    TicketPrice = row.Field<string>("BiletFiyatiInternet"),
                    Route = row.Field<string>("Guzergah"),
                    BusExpeditionTypeDescription = row.Field<string>("SeferTipiAciklamasi"),
                    ExpectedTravelTime = row.Field<string>("YaklasikSeyahatSuresi")
                })
                .ToList();
          
            return items;
        }

        public string CreateBusExpeditionXml(string fromIdRoadPoint, string toIdRoadPoint, DateTime travelDate)
        {
            var sb = new StringBuilder();
            sb.Append("<Sefer>");
            sb.Append("<FirmaNo>0</FirmaNo>");
            sb.Append($"<KalkisNoktaID>{fromIdRoadPoint}</KalkisNoktaID>");
            sb.Append($"<VarisNoktaID>{toIdRoadPoint}</VarisNoktaID>");
            sb.Append($"<Tarih>{travelDate.ToString("yyyy-MM-dd")}</Tarih>");
            sb.Append("<AraNoktaGelsin>1</AraNoktaGelsin>");
            sb.Append("<IslemTipi>0</IslemTipi>");
            sb.Append("<YolcuSayisi>1</YolcuSayisi>");
            sb.Append("<Ip>127.0.0.1</Ip>");
            sb.Append("</Sefer>");

            return sb.ToString();
        }
    }
}
