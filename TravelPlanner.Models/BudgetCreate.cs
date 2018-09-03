using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class BudgetCreate
    {
        public int BudgetID { get; set; }

        [Required]
        [Display(Name ="Budget for:")]
        [MinLength(2, ErrorMessage ="Must be at least 2 Characters")]
        public string BudgetTitle { get; set; }

        [Display(Name = "Travel Cost:")]
        public decimal Transportation { get; set; }

        [Display(Name = "Lodging Cost:")]
        public decimal Lodging { get; set; }

        [Display(Name = "Food Cost:")]
        public decimal FoodCost { get; set; }

        [Display(Name = "Activity Cost:")]
        public decimal Activities { get; set; }

        [Display(Name = "Other:")]
        public decimal Souvenirs { get; set; }

        public override string ToString() => BudgetTitle;

    }
}
