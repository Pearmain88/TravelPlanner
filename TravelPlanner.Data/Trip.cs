using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public class Trip
    {
        [Key]
        public int TripID { get; set; }

        [Required]
        public Guid OwnerID  { get; set; }

        [Required]
        public string TripName { get; set; }

        public DateTimeOffset? DepartDate { get; set; }

        public DateTimeOffset? ReturnDate { get; set; }
    }
}
