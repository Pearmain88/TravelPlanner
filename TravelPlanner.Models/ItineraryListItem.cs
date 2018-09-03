using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data;

namespace TravelPlanner.Models
{
    public class ItineraryListItem
    {
        public int ItineraryID { get; set; }

        [Display(Name ="Completed:")]
        public bool Completed { get; set; }

        [Required]
        [Display(Name="Activity Name:")]
        [MinLength(1, ErrorMessage ="Please fill in the activity name.")]
        public string ActivityName { get; set; }

        [Required]
        [Display(Name ="Description:")]
        [MaxLength(3000, ErrorMessage ="Leave something to the imagination.")]
        public string ActivityDescription { get; set; }

        [Display(Name ="Type:")]
        public ActivityType Type { get; set; }

        [Display(Name ="Cost:")]
        public decimal? ActivityCost { get; set; }

        [Display(Name ="Date:")]
        public DateTimeOffset? ActivityDate { get; set; }




    }
}
