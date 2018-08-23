using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Models;

namespace TravelPlanner.Contracts
{
    public interface IBudgetService
    {
        bool CreateBudget(BudgetCreate model);
        BudgetDetail GetBudgetByID(int budgetID);
        IEnumerable<BudgetListItem> GetBudgets();
        bool UpdateBudget(BudgetEdit model);
        bool DeleteBudget(int budgetID);
    }
}
