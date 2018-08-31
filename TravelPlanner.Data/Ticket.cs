using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public enum TicketType { Identification, TravelTickets, Activity, Receipts }

    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string TicketTitle { get; set; }

        public string Identification { get; set; }
        public string TravelTickets { get; set; }
        public string ActivityTickets { get; set; }
        public string Receipts { get; set; }
    }
}
