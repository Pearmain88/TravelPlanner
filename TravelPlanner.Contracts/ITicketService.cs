using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Models;

namespace TravelPlanner.Contracts
{
    public interface ITicketService
    {
        bool CreateTicket(TicketCreate model);
        TicketDetail GetTicketById(int ticketID);
        IEnumerable<TicketListItem> GetTickets();
        bool UpdateTicket(TicketEdit model);
        bool DeleteTicket(int ticketID);
    }
}
