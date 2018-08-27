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
        [Display(Name ="What I'm Planning For: \n" +
            "(ie: My First Trip To Rome)")]
        [MinLength(2, ErrorMessage ="Must be at least 2 Characters")]
        public string BudgetTitle { get; set; }

        [Display(Name = "How I'm getting there:")]
        public decimal Transportation { get; set; }

        [Display(Name = "Where I'm sleeping:")]
        public decimal Lodging { get; set; }

        [Display(Name = "How much for what I'm eating:")]
        public decimal FoodCost { get; set; }

        [Display(Name = "How much for Activities and Tours:")]
        public decimal Activities { get; set; }

        [Display(Name = "How much on Gifts and Souvenirs:")]
        public decimal Souvenirs { get; set; }

        public override string ToString() => BudgetTitle;

    }
}
