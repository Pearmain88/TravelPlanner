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
        public ActionResult TicketIndex()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new TicketService(userID);
            var model = new TicketListItem[0];

            return View(model);
        }

        public ActionResult TicketCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TicketCreate(TicketCreate model)
        {
            if (ModelState.IsValid) { return View(model); }

            TicketService service = CreateTicketService();

            if (service.CreateTicket(model))
            {
                TempData["SaveResult"] = "Your ticket has been saved.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Trip could not be created.");

            return View(model);
        }

        public ActionResult TicketDetails(int id)
        {
            var service = CreateTicketService();
            var model = service.GetTicketById(id);
            return View(model);
        }

        public ActionResult TicketEdit(int id)
        {
            var service = CreateTicketService();
            var detail = service.GetTicketById(id);
            var model =
                new TicketEdit
                {
                    TicketID = detail.TicketID,
                    TicketTitle = detail.TicketTitle,
                    Identification = detail.Identification,
                    TravelTickets = detail.TravelTickets,
                    ActivityTickets = detail.ActivityTickets,
                    Receipts = detail.Receipts
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TicketEdit(int id, TicketEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TicketID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTicketService();

            if (service.UpdateTicket(model))
            {
                TempData["SaveResult"] = "Your ticket has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your ticket could not be updated");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult TicketDelete(int id)
        {
            var svc = CreateTicketService();
            var model = svc.GetTicketById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTicketPost(int id)
        {
            var service = CreateTicketService();
            service.DeleteTicket(id);
            TempData["SaveResult"] = "Your ticket has been deleted.";
            return RedirectToAction("Index");
        }

        private TicketService CreateTicketService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new TicketService(userID);
            return service;
        }

    }
}