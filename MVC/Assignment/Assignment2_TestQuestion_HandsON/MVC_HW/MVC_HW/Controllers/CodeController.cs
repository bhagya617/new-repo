using System.Linq;
using System.Web.Mvc;
using MVC_HW.Models; 

namespace MvcNorthwindApp.Controllers
{
    public class CodeController : Controller
    {
        private NorthwindEntities _context = new NorthwindEntities();

        public ActionResult GetCustomersInGermany()
        {
            var customers = _context.Customers
                                    .Where(c => c.Country == "Germany")
                                    .ToList();
            return View(customers);
        }

        public ActionResult GetCustomerByOrderId(int orderId = 10248)
        {
            var customer = _context.Orders
                                   .Where(o => o.OrderID == orderId)
                                   .Select(o => o.Customer)
                                   .FirstOrDefault();
            return View(customer);
        }
    }
}
