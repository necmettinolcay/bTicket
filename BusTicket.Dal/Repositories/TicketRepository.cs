using BusTicket.Data.Data;
using BusTicket.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Dal.Repositories
{
    public class TicketRepository : EfRepository<Ticket>
    {
        public TicketRepository(BticketContext dbContext) : base(dbContext)
        {
        }

        public Ticket GetByPnr(string pnr)
        {
            return _dbContext.Tickets.Where(t => t.Pnr.Equals(pnr)).FirstOrDefault();
        }
    }
}
