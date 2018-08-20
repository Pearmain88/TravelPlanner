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

        [Display(Name="Where I want to be:")]
        public string TripName { get; set; }

        [Display(Name ="When I want to be there:")]
        public DateTimeOffset? DepartDate { get; set; }

        [Display(Name ="When I'm coming home:")]
        public DateTimeOffset? ReturnDate { get; set; }

    }
}
