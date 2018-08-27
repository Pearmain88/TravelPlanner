using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class BudgetDetail
    {
        public int BudgetID { get; set; }
        public string BudgetTitle { get; set; }
        public decimal Transportation { get; set; }
        public decimal Lodging { get; set; }
        public decimal FoodCost { get; set; }
        public decimal Activities { get; set; }
        public decimal Souvenirs { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
