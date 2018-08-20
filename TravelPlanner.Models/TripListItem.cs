using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class TripListItem
    {
        public int TripID { get; set; }

        [Display(Name="Where I Want To Be:")]
        public string TripName { get; set; }

        [Display(Name ="When I Want To Be There:")]
        public DateTimeOffset? DepartDate { get; set; }

        [Display(Name ="When I'm Coming Home:")]
        public DateTimeOffset? ReturnDate { get; set; }

        public override string ToString() => TripName;
    }
}
