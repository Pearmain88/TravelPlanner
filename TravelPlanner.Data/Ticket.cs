using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public enum TicketType { Identification = 1, TravelTickets, Activity, Receipts }

    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        [Display(Name ="Title")]
        public string TicketTitle { get; set; }

        [Display(Name ="Type")]
        public TicketType TicketType { get; set; }

        [Display(Name ="Link")]
        public string TicketLink { get; set; }


    }
}
