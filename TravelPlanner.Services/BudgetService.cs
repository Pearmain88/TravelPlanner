using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Contracts;
using TravelPlanner.Data;
using TravelPlanner.Models;
using TravelPlannerAppProject.Models;

namespace TravelPlanner.Services
{
    public class BudgetService : IBudgetService
    {
        //--THIS DOES NOT GO IN CONTRACTS
        private readonly Guid _userID;
        //--THIS DOES NOT GO IN CONTRACTS
        public BudgetService(Guid userID)
        {

            _userID = userID;

        }
        //--THE REST OF THESE GO IN CONTRACTS
        public bool CreateBudget(BudgetCreate model)
        {
            var entity =
                new Budget()
                {
                    OwnerID = _userID,
                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Budgets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public BudgetDetail GetBudgetByID(int budgetID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Budgets
                        .Single(e => e.BudgetID == budgetID && e.OwnerID == _userID);
                return
                    new BudgetDetail
                    {
                        BudgetID = entity.BudgetID,
                        BudgetTitle = entity.BudgetTitle,
                        Transportation = entity.Transportation,
                        Lodging = entity.Lodging,
                        FoodCost = entity.FoodCost,
                        Activities = entity.Activities,
                        Souvenirs = entity.Souvenirs
                    };
            }
        }

        public IEnumerable<BudgetListItem> GetBudgets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Budgets
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new BudgetListItem
                                {
                                    BudgetID = e.BudgetID,
                                    BudgetTitle = e.BudgetTitle,
                                    Transportation = e.Transportation,
                                    Lodging = e.Lodging,
                                    FoodCost = e.FoodCost,
                                    Activities = e.Activities,
                                    Souvenirs = e.Souvenirs,
                                    TotalCost = e.TotalCost
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateBudget(BudgetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Budgets
                        .Single(e => e.BudgetID == model.BudgetID && e.OwnerID == _userID);

                entity.BudgetTitle = model.BudgetTitle;
                entity.Transportation = model.Transportation;
                entity.Lodging = model.Lodging;
                entity.FoodCost = model.FoodCost;
                entity.Activities = model.Activities;
                entity.Souvenirs = model.Souvenirs;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBudget(int budgetID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Budgets
                        .Single(e => e.BudgetID == budgetID && e.OwnerID == _userID);
                ctx.Budgets.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
