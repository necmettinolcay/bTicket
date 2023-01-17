using BusTicket.Data.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Entities
{
    [Serializable]
    public partial class Expedition : BaseEntity
    {
        [NonSerialized]
        public BticketContext _bticketContext;
        
        public Expedition(BticketContext bticketContext)
        {
            _bticketContext = bticketContext;
        }
     
        public Bus _bus;

        [NotMapped]
        public Bus Bus
        {
            get
            {
                if (_bus == null || !_bus.IdBus.Equals(IdBus))
                {
                    return _bticketContext.Buses.Find(IdBus);
                }
                else
                {
                    return _bus;
                }
            }
            set
            {
                _bus = value;
            }
        }

        public Company _company;

        [NotMapped]
        public Company Company
        {
            get
            {
                if (_company == null || !_company.IdCompany.Equals(IdCompany))
                {
                    return _bticketContext.Companies.Find(IdCompany);
                }
                else
                {
                    return _company;
                }
            }
            set
            {
                _company = value;
            }
        }

        public ExpeditionType _expeditionType;

        [NotMapped]
        public ExpeditionType ExpeditionType
        {
            get
            {
                if (_expeditionType == null || !_expeditionType.IdExpeditionType.Equals(IdExpeditionType))
                {
                    return _bticketContext.ExpeditionTypes.Find(IdExpeditionType);
                }
                else
                {
                    return _expeditionType;
                }
            }
            set
            {
                _expeditionType = value;
            }
        }
    }
}
