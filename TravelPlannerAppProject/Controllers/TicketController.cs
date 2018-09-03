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
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new TicketService(userID);
            var model = service.GetTickets();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketCreate model)
        {
            if (!ModelState.IsValid) { return View(model); }

            TicketService service = CreateService();

            if (service.CreateTicket(model))
            {
                TempData["SaveResult"] = "Your ticket has been saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Trip could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateService();
            var model = service.GetTicketById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateService();
            var detail = service.GetTicketById(id);
            var model =
                new TicketEdit
                {
                    TicketID = detail.TicketID,
                    TicketTitle = detail.TicketTitle,
                    TicketType = detail.TicketType,
                    TicketLink = detail.TicketLink
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TicketEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TicketID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateService();

            if (service.UpdateTicket(model))
            {
                TempData["SaveResult"] = "Your ticket has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your ticket could not be updated");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateService();
            var model = svc.GetTicketById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateService();
            service.DeleteTicket(id);
            TempData["SaveResult"] = "Your ticket has been deleted.";
            return RedirectToAction("Index");
        }

        private TicketService CreateService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new TicketService(userID);
            return service;
        }

    }
}