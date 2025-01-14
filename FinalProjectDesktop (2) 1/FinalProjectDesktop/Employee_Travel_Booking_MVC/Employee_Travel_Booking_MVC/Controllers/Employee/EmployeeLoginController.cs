using System;
using System.Linq;
using System.Web.Mvc;
using Employee_Travel_Booking_MVC.Models;

namespace Employee_Travel_Booking_MVC.Controllers.Employee
{
    public class EmployeeLoginController : Controller
    {
        private readonly Employee_Travel_Booking_SystemDB1Entities1 db;

        public EmployeeLoginController()
        {
            // Initialize the DbContext
            db = new Employee_Travel_Booking_SystemDB1Entities1();
        }

        // GET: Login Page
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
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

                // Retrieve the employee by email and password
                var emp = db.employees.FirstOrDefault(a => a.email == email && a.emp_password == password);

                // Validate employee existence and active status
                if (emp != null)
                {
                    if (emp.status == true) // Check if the employee is active
                    {
                        // Store employee details in session
                        Session["EmployeeId"] = emp.employeeid;
                        Session["EmployeeName"] = emp.emp_name;
                        Session["EmployeeEmail"] = emp.email;

                        // Redirect to the dashboard or home page
                        return RedirectToAction("Index", "TravelRequests");
                    }
                    else
                    {
                        throw new Exception("Your account is inactive. Please contact your manager or administrator.");
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

        // Logout Action
        public ActionResult Logout()
        {
            // Clear session
            Session.Clear();
            return RedirectToAction("Login", "EmployeeLogin");
        }

        // GET: Forgot Password Page
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: Forgot Password
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

                var emp = db.employees.FirstOrDefault(a => a.email == email);
                if (emp == null)
                {
                    throw new Exception("Email not found.");
                }

                // Redirect to the ResetPassword action with the employee ID
                return RedirectToAction("ResetPassword", new { id = emp.employeeid });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Reset Password Page
        [HttpGet]
        public ActionResult ResetPassword(int id)
        {
            var emp = db.employees.FirstOrDefault(a => a.employeeid == id);
            if (emp == null)
            {
                TempData["ErrorMessage"] = "Invalid password reset request.";
                return RedirectToAction("Login");
            }

            ViewBag.EmployeeId = id;
            return View();
        }

        // POST: Reset Password
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
                    ViewBag.EmployeeId = id;
                    return View();
                }

                var emp = db.employees.FirstOrDefault(a => a.employeeid == id);
                if (emp == null)
                {
                    throw new Exception("Invalid password reset request.");
                }

                emp.emp_password = password;
                db.SaveChanges();

                TempData["SuccessMessage"] = "Password has been reset successfully.";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}