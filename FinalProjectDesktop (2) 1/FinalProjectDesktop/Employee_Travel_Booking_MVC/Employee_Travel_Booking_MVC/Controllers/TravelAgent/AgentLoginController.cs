using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Employee_Travel_Booking_MVC.Models;

namespace Employee_Travel_Booking_MVC.Controllers.TravelAgent
{
    public class AgentLoginController : Controller
    {
        private readonly Employee_Travel_Booking_SystemDB1Entities1 db;

        public AgentLoginController()
        {
            db = new Employee_Travel_Booking_SystemDB1Entities1();
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

                // Retrieve the travel agent by email and password
                var agent = db.travelagents.FirstOrDefault(a => a.email == email && a.travel_agent_password == password);

                // Validate travel agent existence, password, and status
                if (agent != null)
                {
                    if (agent.status == true) // Check if the travel agent is active
                    {
                        Session["AgentId"] = agent.agentid;
                        Session["AgentName"] = agent.name;
                        Session["email"] = email;

                        FormsAuthentication.SetAuthCookie(email, false);

                        // Redirect to the dashboard controller
                        return RedirectToAction("AgentIndex", "AgentDashboard");
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
            return RedirectToAction("Login", "AgentLogin");
        }
    }
}