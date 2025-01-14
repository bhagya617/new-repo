using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_Travel_Booking_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index(string empName)
        {
            ViewBag.EmployeeName = empName; // Store the passed employee name in ViewBag
            return View();
        }
    }
}