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
    public partial class Ticket : BaseEntity
    {
        [NonSerialized]
        public BticketContext _bticketContext;
        
        public Ticket (BticketContext bticketContext)
        {
            _bticketContext = bticketContext;
        }

        public Expedition _expedition;
     
        [NotMapped]
        public Expedition Expedition
        {
            get
            {
                if (_expedition == null || !_expedition.IdExpedition.Equals(IdExpedition) )
                {
                    return _bticketContext.Expeditions.Find(IdExpedition);
                }
                else
                {
                    return _expedition;
                }
            }
            set
            {
                _expedition = value;
            }
        }

        public Passenger _passenger;

        [NotMapped]
        public Passenger Passenger
        {
            get
            {
                if (_expedition == null || !_passenger.IdPassenger.Equals(IdPassenger))
                {
                    return _bticketContext.Passengers.Find(IdPassenger);
                }
                else
                {
                    return _passenger;
                }
            }
            set
            {
                _passenger = value;
            }
        }

        public Point _departurePoint;

        [NotMapped]
        public Point DeparturePoint
        {
            get
            {
                if (_departurePoint == null || !_departurePoint.IdPoint.Equals(IdDeparturePoint))
                {
                    return _bticketContext.Points.Find(IdDeparturePoint);
                }
                else
                {
                    return _departurePoint;
                }
            }
            set
            {
                _departurePoint = value;
            }
        }

        public Point _arrivalPoint;

        [NotMapped]
        public Point ArrivalPoint
        {
            get
            {
                if (_arrivalPoint == null || !_arrivalPoint.IdPoint.Equals(IdArrivalPoint))
                {
                    return _bticketContext.Points.Find(IdArrivalPoint);
                }
                else
                {
                    return _arrivalPoint;
                }
            }
            set
            {
                _arrivalPoint = value;
            }
        }

        public string Service { get { return ServiceRequest == 1 ? "Evet" : "Hayır"; } }
    }
}
