﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_Travel_Booking_MVC.Models;

namespace Employee_Travel_Booking_MVC.Controllers.ManagerMenu
{
    [Authorize]
    public class ManagerController : Controller
    {

        Employee_Travel_Booking_SystemDB1Entities1 db = new Employee_Travel_Booking_SystemDB1Entities1();


        // GET: Manager
        public ActionResult ManagerDashboard()
        {
            return View();
        }
        public ActionResult Requests()
        {
            // Get the manager's login ID from the session
            int? managerId = Session["ManagerId"] as int?;

            // Retrieve travel requests of employees reporting to this manager
            var pendingRequests = db.travelrequests.Where(r => r.approvalstatus == "pending" && r.employee.managerid == managerId).ToList();
            return View(pendingRequests);
        }

        // GET: Manager/Details/5
        public ActionResult Details(int id)
        {
            // Retrieve the details of a specific travel request
            var request = db.travelrequests.FirstOrDefault(x => x.requestid == id);
            return View(request);
        }

        // POST: Manager/Approve/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve(int id)
        {
            // Update the status of the travel request to "Approved"
            var request = db.travelrequests.Find(id);
            request.approvalstatus = "Approved";
            db.SaveChanges();
            return RedirectToAction("Requests");
        }

        // POST: Manager/Reject/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reject(int id)
        {
            // Update the status of the travel request to "Rejected"
            var request = db.travelrequests.Find(id);
            request.approvalstatus = "Rejected";
            db.SaveChanges();
            return RedirectToAction("Requests");
        }

        public ActionResult RequestHistory()
        {
            // Get the manager's login ID from the session
            int? managerId = Session["ManagerId"] as int?;

            // Retrieve the history of travel requests made by reporting employees
            var requestHistory = db.travelrequests.Where(r => r.employeeid == r.employeeid && r.employee.managerid == managerId).ToList();
            return View(requestHistory);
        }

        // GET: Manager/ViewEmployees
        public ActionResult ViewEmployees()
        {
            // Get the manager's login ID from the session
            int? managerId = Session["ManagerId"] as int?;

            // Retrieve the list of employees who report to this manager
            var employees = db.employees.Where(e => e.managerid == managerId).ToList();
            return View(employees);
        }

    }
}