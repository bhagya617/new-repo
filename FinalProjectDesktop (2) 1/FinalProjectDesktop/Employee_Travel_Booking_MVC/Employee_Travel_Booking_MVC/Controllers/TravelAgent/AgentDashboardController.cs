using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Employee_Travel_Booking_MVC.Models;

namespace Employee_Travel_Booking_MVC.Controllers.TravelAgent
{
    public class AgentDashboardController : Controller
    {
        // GET: AgentDashboard
       
        private readonly Employee_Travel_Booking_SystemDB1Entities1 db;
        public AgentDashboardController()
        {
            db = new Employee_Travel_Booking_SystemDB1Entities1();//Initialize DbContext
        }
        // GET: AgentDashboard
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult AgentIndex()
        {
          
            // Retrieve pending travel requests and pass them to the view
            var pendingRequests = db.travelrequests;
            return View(pendingRequests);
        }

        // Action to update the status of a travel request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStatus(int requestId, string status)
        {
            try
            {
                var travelRequest = db.travelrequests.FirstOrDefault(tr => tr.requestid == requestId);
                if (travelRequest == null)
                {
                    throw new Exception("Travel request not found.");
                }

                travelRequest.bookingstatus = status;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Booking status updated successfully.";

                //if (status.Equals("Confirmed", StringComparison.OrdinalIgnoreCase))
                //{
                //    var employee = db.employees.FirstOrDefault(e => e.employeeid == travelRequest.employeeid);
                //    if (employee != null)
                //    {
                //        string message = $"Dear {employee.emp_name}, your travel request (ID: {requestId}) has been confirmed. You will get further Details Soon.... Thank you";
                //        //await _smsService.SendSmsAsync(employee.phonenumber, message);
                //    }
                //}
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("AgentIndex");
        }
    }
}