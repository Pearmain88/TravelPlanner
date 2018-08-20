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

        [Display(Name = "Aaaand the Grand Total is...:")]
        public decimal TotalCost { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
