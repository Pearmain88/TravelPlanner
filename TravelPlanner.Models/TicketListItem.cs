using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data;

namespace TravelPlanner.Models
{
    public class TicketListItem
    {
        public int TicketID { get; set; }

        [Display(Name ="Name:")]
        public string TicketTitle { get; set; }

        [Display(Name ="Type:")]
        public TicketType TicketType { get; set; }

        [Display(Name ="Link to digital Ticket:")]
        public string TicketLink { get; set; }
    }
}
