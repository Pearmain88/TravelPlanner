using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public class TripDetail
    {
        public int TripID { get; set; }

        [Display(Name="Place I'm Going:")]
        public string TripName { get; set; }

        [Display(Name ="Departure Date:")]
        public DateTimeOffset? DepartDate { get; set; }

        [Display(Name ="Return Date:")]
        public DateTimeOffset? ReturnDate { get; set; }

    }
}
