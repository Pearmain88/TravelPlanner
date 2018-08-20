using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class ItineraryCreate
    {
        [Required]
        [MinLength(1, ErrorMessage ="Please name this activity.")]
        [MaxLength(100, ErrorMessage ="Thats a little too long.")]
        public string ActivityName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage ="Please enter a description.")]
        [MaxLength(3000, ErrorMessage ="Leave something to the imagination")]
        public string ActivityDescription { get; set; }

        public decimal? ActivityCost { get; set; }

        public DateTimeOffset? ActivityDate { get; set; }

        public override string ToString() => ActivityName;

    }
}
