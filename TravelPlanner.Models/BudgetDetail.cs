using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class BudgetDetail
    {
        public int BudgetID { get; set; }
        [Display(Name = "Budget for:")]
        public string BudgetTitle { get; set; }
        [Display(Name ="Travel Cost:")]
        public decimal Transportation { get; set; }
        [Display(Name ="Lodging Cost:")]
        public decimal Lodging { get; set; }
        [Display(Name ="Food Cost:")]
        public decimal FoodCost { get; set; }
        [Display(Name ="Activity Cost:")]
        public decimal Activities { get; set; }
        [Display(Name ="Other:")]
        public decimal Souvenirs { get; set; }

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
