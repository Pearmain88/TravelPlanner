using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class TicketCreate
    {
        public int TicketID { get; set; }
        public string TicketTitle { get; set; }
        public string Identification { get; set; }
        public string TravelTickets { get; set; }
        public string ActivityTickets { get; set; }
        public string Receipts { get; set; }

        public override string ToString() => TicketTitle;
        
    }
}
