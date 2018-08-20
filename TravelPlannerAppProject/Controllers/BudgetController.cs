using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelPlanner.Models;
using TravelPlanner.Services;

namespace TravelPlannerAppProject.Controllers
{
    [Authorize]
    public class BudgetController : Controller
    {
        // GET: Budget
        public ActionResult Index()
        {
            var model = new BudgetListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BudgetCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBudgetService();

            if (service.CreateBudget(model))
            {
                TempData["SaveResult"] = "Your Budget Item(s) is saved!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Budget Item(s) could not be saved.");
            return View(model);
        }

        private BudgetService CreateBudgetService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BudgetService(userID);
            return service;
        }

        public ActionResult BudgetDetails(int id)
        {
            var service = CreateBudgetService();
            var model = service.GetBudgetByID(id);
            return View(model);
        }

        public ActionResult BudgetEdit(int id)
        {
            var service = CreateBudgetService();
            var detail = service.GetBudgetByID(id);
            var model =
                new BudgetEdit
                {
                    BudgetID = detail.BudgetID,
                    BudgetTitle = detail.BudgetTitle,
                    Transportation = detail.Transportation,
                    Lodging = detail.Lodging,
                    FoodCost = detail.FoodCost,
                    Activities = detail.Activities,
                    Souvenirs = detail.Souvenirs
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BudgetEdit(int id, BudgetEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BudgetID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBudgetService();

            if (service.UpdateBudget(model))
            {
                TempData["SaveResult"] = "Your activity has been updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your activity could not be updated.");
            return View(model);
        }

        public ActionResult BudgetDelete(int id)
        {
            var service = CreateBudgetService();
            var model = service.GetBudgetByID(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult BudgetDeletePost(int id)
        {
            var service = CreateBudgetService();
            service.DeleteBudget(id);
            TempData["SaveResult"] = "your budget item has been deleted.";
            return RedirectToAction("Index");
        }



    }
}