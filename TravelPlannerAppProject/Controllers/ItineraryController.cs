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
        public ActionResult ItineraryIndex()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ItineraryService(userID);
            var model = service.GetItineraries();
            return View();
        }

        public ActionResult ItineraryCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ItineraryCreate(ItineraryCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateItineraryService();

            if (service.CreateItinerary(model))
            {
                TempData["SaveResult"] = "Your activity is saved!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Activity could not be saved.");
            return View(model);
        }

        private ItineraryService CreateItineraryService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ItineraryService(userID);
            return service;
        }

        public ActionResult ItineraryDetails(int id)
        {
            var service = CreateItineraryService();
            var model = service.GetItineraryByID(id);
            return View(model);
        }

        public ActionResult ItineraryEdit(int id)
        {
            var service = CreateItineraryService();
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
        public ActionResult ItineraryEdit(int id, ItineraryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ItineraryID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateItineraryService();

            if(service.UpdateItinerary(model))
            {
                TempData["SaveResult"] = "Your activity has been updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your activity could not be updated.");
            return View(model);
        }

        public ActionResult ItineraryDelete(int id)
        {
            var service = CreateItineraryService();
            var model = service.GetItineraryByID(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ItineraryDeletePost(int id)
        {
            var service = CreateItineraryService();
            service.DeleteItinerary(id);
            TempData["SaveResult"] = "Your activity has been deleted.";
            return RedirectToAction("Index");
        }
    }
}