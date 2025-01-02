using System.Linq;
using System.Web.Mvc;
using MVC_CC;


public class CodeController : Controller
{
    private NorthwindEntities db = new NorthwindEntities(); 

    public ActionResult CustomersInGermany()
    {
        var customersInGermany = db.Customers.Where(c => c.Country == "Germany").ToList();
        return View(customersInGermany);
    }

    public ActionResult CustomerDetails(int orderId)
    {
        var customerDetails = db.Orders
            .Where(o => o.OrderID == orderId)
            .Select(o => o.Customer)
            .FirstOrDefault();

        return View(customerDetails);
    }
}