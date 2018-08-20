using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class ItineraryListItem
    {
        public int ItineraryID { get; set; }

        public bool Completed { get; set; }

        [Required]
        [Display(Name="What's happening:")]
        [MinLength(1, ErrorMessage ="Please fill in the activity name.")]
        public string ActivityName { get; set; }

        [Required]
        [Display(Name ="What's going to happen")]
        [MaxLength(3000, ErrorMessage ="Leave something to the imagination.")]
        public string ActivityDescription { get; set; }

        [Display(Name ="How much is this going to cost? \n" +
            "Be sure to round up if there's a gift shop!")]
        public decimal? ActivityCost { get; set; }

        [Display(Name ="When is this going to happen?")]
        public DateTimeOffset? ActivityDate { get; set; }




    }
}
