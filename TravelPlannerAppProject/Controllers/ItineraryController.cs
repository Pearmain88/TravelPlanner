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
    public class ItineraryController : Controller
    {
        // GET: Itinerary
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ItineraryService(userID);
            var model = service.GetItineraries();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItineraryCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateService();

            if (service.CreateItinerary(model))
            {
                TempData["SaveResult"] = "Your activity is saved!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Activity could not be saved.");
            return View(model);
        }

        private ItineraryService CreateService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ItineraryService(userID);
            return service;
        }

        public ActionResult Details(int id)
        {
            var service = CreateService();
            var model = service.GetItineraryByID(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateService();
            var detail = service.GetItineraryByID(id);
            var model =
                new ItineraryEdit
                {
                    ItineraryID = detail.ItineraryID,                 
                    ActivityName = detail.ActivityName,
                    Completed = detail.Completed,
                    ActivityDescription = detail.ActivityDescription,
                    ActivityCost = detail.ActivityCost,
                    ActivityDate = detail.ActivityDate
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItineraryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ItineraryID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateService();

            if(service.UpdateItinerary(model))
            {
                TempData["SaveResult"] = "Your activity has been updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your activity could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateService();
            var model = service.GetItineraryByID(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateService();
            service.DeleteItinerary(id);
            TempData["SaveResult"] = "Your activity has been deleted.";
            return RedirectToAction("Index");
        }
    }
}