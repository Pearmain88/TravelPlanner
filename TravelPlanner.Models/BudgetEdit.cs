using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class BudgetEdit
    {
        public int BudgetID { get; set; }
        [Display(Name = "Budget for:")]
        public string BudgetTitle { get; set; }
        [Display(Name ="Transprotation cost:")]
        public decimal Transportation { get; set; }
        [Display(Name = "Lodging cost:" )]
        public decimal Lodging { get; set; }
        [Display(Name ="Estimated food cost:")]
        public decimal FoodCost { get; set; }
        [Display(Name ="Activities cost:")]
        public decimal Activities { get; set; }
        [Display(Name ="Souvenirs and gifts:")]
        public decimal Souvenirs { get; set; }
    }
}
