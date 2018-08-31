using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public enum ActivityType { Tour = 1, Dining, Attraction, Park, Landmark, Museum, Other }

    public class Itinerary
    {
        [Key]
        public int ItineraryID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        public bool Completed { get; set; }

        [Required]        
        public string ActivityName { get; set; }

        [Required]
        public ActivityType Type { get; set; }

        [Required]
        public string ActivityDescription { get; set; }

        public decimal? ActivityCost { get; set; }

        public DateTimeOffset? ActivityDate { get; set; }
    }
}
