using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class TripCreate
    {
        [Required]
        [MinLength(1, ErrorMessage ="Please Name Your Trip.")]
        [MaxLength(100, ErrorMessage ="That's A Little Too Long.")]
        [Display(Name ="Place I'm Going:")]
        public string TripName { get; set; }

        [Display(Name ="Departure Date:")]
        public DateTimeOffset? DepartDate { get; set; }

        [Display(Name ="Return Date:")]
        public DateTimeOffset? ReturnDate { get; set; }

        public override string ToString() => TripName;

    }
}
