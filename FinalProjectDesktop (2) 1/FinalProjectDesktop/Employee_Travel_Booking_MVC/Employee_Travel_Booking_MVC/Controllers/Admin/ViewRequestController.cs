using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_Travel_Booking_MVC.Models;

namespace Employee_Travel_Booking_MVC.Controllers.Admin
{
    public class ViewRequestController : Controller
    {
        private readonly Employee_Travel_Booking_SystemDB1Entities1 db;

        public ViewRequestController()
        {
            db = new Employee_Travel_Booking_SystemDB1Entities1();
        }
        // GET: ViewRequest
        [HttpGet]
        public ActionResult GetViewRequest()
        {
            var travelRequests = db.travelrequests.ToList();
            return View(travelRequests);
        }
    }
}