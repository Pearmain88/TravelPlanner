using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class TripEdit
    {
        public int TripID { get; set; }
        public string TripName { get; set; }
        public DateTimeOffset? DepartDate { get; set; }
        public DateTimeOffset? Returndate { get; set; }
    }
}
