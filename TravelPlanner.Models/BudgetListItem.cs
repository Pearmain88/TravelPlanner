using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class BudgetListItem
    {
        public int BudgetID { get; set; }

        [Display(Name ="What I'm planning for:")]
        public string BudgetTitle { get; set; }

        [Display(Name = "Travel Cost:")]
        public decimal Transportation { get; set; }

        [Display(Name = "Lodging Cost:")]
        public decimal Lodging { get; set; }

        [Display(Name = "Food Cost:")]
        public decimal FoodCost { get; set; }

        [Display(Name = "Activity Cost:")]
        public decimal Activities { get; set; }

        [Display(Name = "Other Cost:")]
        public decimal Souvenirs { get; set; }

        [Display(Name = "Grand Total:")]
        private decimal totalCost;

        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = Transportation + Lodging + FoodCost + Activities + Souvenirs; }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
