using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstWebApp.Controllers
{
    public class HomeController : Controller//all controllers should inherit from the Controller class and will have controller suffix
    {
        private readonly ILogger<HomeController> _logger;//logger object to log messages and errors - Explain later

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()//action methods that will be called when the user navigates to the URL
        {
            return View();//Go to the view folder identify the folder with the same name as the controller and then the view with the same name as the action method
                          //execute the c# code in the view and return the HTML to the browser

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
