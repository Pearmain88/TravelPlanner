using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Data
{
    public class Budget
    {
        [Key]
        public int BudgetID { get; set; }
        public decimal Transportation { get; set; }
        public decimal Lodging { get; set; }
        public decimal FoodCost { get; set; }
        public decimal Activities { get; set; }
        public decimal Souvenirs { get; set; }

        private decimal totalCost;

        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }




    }
}
