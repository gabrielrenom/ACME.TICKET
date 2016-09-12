using ACME.Business.Services;
using ACME.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACME.Common.Interfaces;
using ACME.Data;
using System.Configuration;
using ACME.Common.Models;

namespace ACME.Web.Controllers
{
    public class TicketController : Controller
    {
        private IAvailableService availableService;
        private ITicketService ticketService;


        public TicketController(IAvailableService availableservice, ITicketService ticketservice)
        {
            availableService = availableservice;
            ticketService = ticketservice;

            availableService.Address = ConfigurationManager.AppSettings["ACME:AvailabilityHandler"];
            ticketService.Address = ConfigurationManager.AppSettings["ACME:TicketHandler"];

        }
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(string FirstName,string LastName,string Address,string CCName,DateTime Date,string CCNumber)
        {
            try
            {               
                if (availableService.IsDateAvailable(Date))
                {
                    ticketService.AddAsync(new TicketModel { Address = Address, CCName = CCName , FirstName = FirstName, CCNumber = CCNumber, LastName = LastName, Date=Date });
                    return View("TicketAdded");
                }
                else
                    return View("TicketNotAvailable");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
