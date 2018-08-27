using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Contracts;
using TravelPlanner.Data;
using TravelPlanner.Models;
using TravelPlannerAppProject.Models;

namespace TravelPlanner.Services
{
    public class TicketService : ITicketService
    {
        private readonly Guid _userID;

        public TicketService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateTicket(TicketCreate model)
        {
            var entity =
                new Ticket()
                {
                    OwnerID = _userID,
                    TicketTitle = model.TicketTitle,
                    Identification = model.Identification,
                    TravelTickets = model.TravelTickets,
                    ActivityTickets = model.ActivityTickets,
                    Receipts = model.Receipts
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tickets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public TicketDetail GetTicketById(int ticketID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tickets
                        .Single(e => e.TicketID == ticketID && e.OwnerID == _userID);
                return
                    new TicketDetail
                    {
                        TicketID = entity.TicketID,
                        TicketTitle = entity.TicketTitle,
                        Identification = entity.Identification,
                        TravelTickets = entity.TravelTickets,
                        ActivityTickets = entity.ActivityTickets,
                        Receipts = entity.Receipts
                    };
            }
        }

        public IEnumerable<TicketListItem> GetTickets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tickets
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new TicketListItem
                                {
                                    TicketID = e.TicketID,
                                    Identification = e.Identification,
                                    TravelTickets = e.TravelTickets,
                                    ActivityTickets = e.ActivityTickets,
                                    Receipts = e.Receipts
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateTicket(TicketEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tickets
                        .Single(e => e.TicketID == model.TicketID && e.OwnerID == _userID);

                entity.TicketID = model.TicketID;
                entity.TicketTitle = model.TicketTitle;
                entity.Identification = model.Identification;
                entity.TravelTickets = model.TravelTickets;
                entity.ActivityTickets = model.ActivityTickets;
                entity.Receipts = model.Receipts;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTicket(int ticketID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tickets
                        .Single(e => e.TicketID == ticketID && e.OwnerID == _userID);
                ctx.Tickets.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
