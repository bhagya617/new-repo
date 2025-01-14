using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_Travel_Booking_MVC.Models;
using System.Web.Security;

namespace Employee_Travel_Booking_MVC.Controllers.Admin
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        private readonly Employee_Travel_Booking_SystemDB1Entities1 db; // Replace YourDbContext with your actual DbContext class

        public AdminLoginController()
        {
            db = new Employee_Travel_Booking_SystemDB1Entities1(); // Initialize your DbContext
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("Email and password are required.");
                }

                // Retrieve the admin by email
                var admin = db.admins.FirstOrDefault(a => a.email == email && a.admin_password == password);

                // Validate admin existence and password
                if (admin != null)
                {
                    Session["email"] = email;
                    Session["password"] = password;
                    FormsAuthentication.SetAuthCookie(email, false);
                    // Redirect to the dashboard controller
                    return RedirectToAction("Index", "AdminDashboard");
                }
                else
                {
                    throw new Exception("Invalid email or password.");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "AdminLogin");
        }
    }
}