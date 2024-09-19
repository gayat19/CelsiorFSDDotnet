using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{

    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Customer Name"] = "John Doe";
            ViewData["Customer Age"] = 30;
            ViewData["Customer"] = new Customer { Id = 1, Name = "John Doe", Age = 30 };

            ViewBag.Customer = "Just the name";
            return View();
        }

        public IActionResult ViewCustomerData()
        {
            Customer customer = new Customer { Id = 1, Name = "John Doe", Age = 30 };
            return View(customer);//by passing the customer object to the view method, we are passing the customer object to the view.
        }
    }
}
