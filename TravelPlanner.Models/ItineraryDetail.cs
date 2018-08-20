using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class ItineraryDetail
    {
        public int ItineraryID { get; set; }

        public bool Completed { get; set; }

        [Display(Name ="What I am doing:")]
        public string ActivityName {get; set; }

        [Display(Name ="What's going to happen:")]
        public string ActivityDescription { get; set; }

        [Display(Name ="How much:")]
        public decimal? ActivityCost { get; set; }

        [Display(Name ="When it's happening:")]
        public DateTimeOffset? ActivityDate { get; set; }
    }
}
