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
    public class TripController : Controller
    {
        // GET: Trip
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new TripService(userID);
            var model = service.GetTrips();
            return View(model);
        }

        //Gets the View For Create, need to make a view and a model for the view
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TripCreate model)
        {
            if (ModelState.IsValid)  return View(model); 

            var service = CreateService();

            if (service.CreateTrip(model))
            {
                TempData["SaveResult"] = "Your trip has been saved.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Trip could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateService();
            var model = svc.GetTripById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateService();
            var detail = service.GetTripById(id);
            var model =
                new TripEdit
                {                    
                    TripName = detail.TripName,
                    DepartDate = detail.DepartDate,
                    Returndate = detail.ReturnDate
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TripEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.TripID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateService();

            if (service.UpdateTrip(model))
            {
                TempData["SaveResult"] = "Your trip has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your trip could not be updated");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateService();
            var model = svc.GetTripById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult TripPost(int id)
        {
            var service = CreateService();
            service.DeleteTrip(id);
            TempData["SaveResult"] = "Your trip has been deleted.";
            return RedirectToAction("Index");
        }

        private TripService CreateService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new TripService(userID);
            return service;
        }
    }
}