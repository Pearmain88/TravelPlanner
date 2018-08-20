using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        public string Identification { get; set; }
        public string TravelTickets { get; set; }
        public string ActivityTickets { get; set; }
        public string Receipts { get; set; }
    }
}
