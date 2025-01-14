using System;

using System.Collections.Generic;

using System.Linq;

using System.Net.Http;

using System.Threading.Tasks;

using System.Web;

using System.Web.Mvc;

using Employee_Travel_Booking_MVC.Models;

using Newtonsoft.Json;

using System.Net;

namespace Employee_Travel_Booking_MVC.Controllers

{

    public class MenuController : Controller

    {

        // GET: Menu

        [HttpGet]

        public ActionResult Create()

        {

            return View();

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Create(Menu e)

        {

            //using (var webclient = new HttpClient())

            //{

            //    webclient.BaseAddress = new Uri("https://localhost:44370/api/");

            //        var postTalk = webclient.PostAsJsonAsync<Menu>("Menu", e);

            //        postTalk.Wait();

            //        var dataResult = postTalk.Result;

            //        if (dataResult.IsSuccessStatusCode)

            //        {

            //            var encodedEmpName = HttpUtility.UrlEncode(e.EmployeeName);

            //            return RedirectToAction("Index", "Login", new { empName = encodedEmpName });

            //        }

            //        else

            //        {

            //            ModelState.AddModelError("", "There was an error saving the data.");

            //            return View(e);

            //        }


            //}
            try
            {
                using (var webclient = new HttpClient())
                {
                    webclient.BaseAddress = new Uri("https://localhost:44370/api/");

                    try
                    {
                        // Attempt to post the data to the API
                        var postTalk = webclient.PostAsJsonAsync<Menu>("Menu", e);
                        postTalk.Wait(); // Wait for the response
                        var dataResult = postTalk.Result;

                        // Check if the response is successful
                        if (dataResult.IsSuccessStatusCode)
                        {
                            // Encode employee name and redirect to the login page
                            var encodedEmpName = HttpUtility.UrlEncode(e.EmployeeName);
                            return RedirectToAction("Index", "Login", new { empName = encodedEmpName });
                        }
                        else
                        {
                            // Handle an unsuccessful response from the API
                            ModelState.AddModelError("", "There was an error saving the data. Please try again.");
                            return View(e);
                        }
                    }
                    catch (AggregateException ex)
                    {
                        // Handle exceptions related to the Task (e.g., timeout or connection issues)
                        foreach (var innerEx in ex.InnerExceptions)
                        {
                            ModelState.AddModelError("", "An error occurred: " + innerEx.Message);
                        }
                        return View(e);
                    }
                    catch (Exception ex)
                    {
                        // Handle other general exceptions
                        ModelState.AddModelError("", "An unexpected error occurred: " + ex.Message);
                        return View(e);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions related to the HttpClient or other critical issues
                ModelState.AddModelError("", "A critical error occurred: " + ex.Message);
                return View(e);
            }
        }

    }

}


