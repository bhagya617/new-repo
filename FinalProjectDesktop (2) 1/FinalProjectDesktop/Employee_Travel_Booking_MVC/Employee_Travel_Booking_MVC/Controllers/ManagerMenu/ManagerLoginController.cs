using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Employee_Travel_Booking_MVC.Models;

namespace Employee_Travel_Booking_MVC.Controllers.ManagerMenu
{
    public class ManagerLoginController : Controller
    {
        private readonly Employee_Travel_Booking_SystemDB1Entities1 db;

        public ManagerLoginController()
        {
            db = new Employee_Travel_Booking_SystemDB1Entities1();
        }

        // GET: ManagerLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ManagerLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManagerLogin(string email, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("Email and password are required.");
                }

                // Retrieve the manager by email and password
                var manager = db.managers.FirstOrDefault(a => a.email == email && a.mgr_password == password);

                // Validate manager existence, password, and status
                if (manager != null)
                {
                    if (manager.status == true) // Check if the manager is active
                    {
                        Session["ManagerId"] = manager.managerid;
                        Session["ManagerName"] = manager.name;
                        Session["email"] = email;

                        FormsAuthentication.SetAuthCookie(email, false);

                        // Redirect to the dashboard controller
                        return RedirectToAction("ManagerDashboard", "Manager");
                    }
                    else
                    {
                        throw new Exception("Your account is inactive. Please contact the administrator.");
                    }
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
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("ManagerLogin", "ManagerLogin");
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    throw new Exception("Email is required.");
                }

                var mgr = db.managers.FirstOrDefault(a => a.email == email);
                if (mgr == null)
                {
                    throw new Exception("Email not found.");
                }

                // Redirect to the ResetPassword action with the manager ID
                return RedirectToAction("ResetPassword", new { id = mgr.managerid });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ResetPassword(int id)
        {
            var mgr = db.managers.FirstOrDefault(a => a.managerid == id);
            if (mgr == null)
            {
                TempData["ErrorMessage"] = "Invalid password reset request.";
                return RedirectToAction("ManagerLogin");
            }

            ViewBag.ManagerId = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(int id, string password, string confirmPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
                {
                    throw new Exception("Password and confirm password are required.");
                }

                if (password != confirmPassword)
                {
                    ModelState.AddModelError("PasswordMismatch", "Passwords do not match.");
                    ViewBag.ManagerId = id;
                    return View();
                }

                var mgr = db.managers.FirstOrDefault(a => a.managerid == id);
                if (mgr == null)
                {
                    throw new Exception("Invalid password reset request.");
                }

                mgr.mgr_password = password;
                db.SaveChanges();

                TempData["SuccessMessage"] = "Password has been reset successfully.";
                return RedirectToAction("ManagerLogin");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}

