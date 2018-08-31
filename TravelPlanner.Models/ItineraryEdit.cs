using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data;

namespace TravelPlanner.Models
{
    public class ItineraryEdit
    {

        public int ItineraryID { get; set; }

        public bool Completed { get; set; }

        public ActivityType Type { get; set; }

        public string ActivityName { get; set; }

        public string ActivityDescription { get; set; }

        public decimal? ActivityCost { get; set; }

        public DateTimeOffset? ActivityDate { get; set; }



    }
}
