using System;
using System.Collections.Generic;

#nullable disable

namespace BusTicket.Data.Entities
{
    public class Company
    {
        public int IdCompany { get; set; }
        public string CompanyName { get; set; }
        public int? Status { get; set; }
    }
}
