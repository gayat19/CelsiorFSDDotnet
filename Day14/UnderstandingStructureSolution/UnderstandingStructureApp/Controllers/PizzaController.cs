using Microsoft.AspNetCore.Mvc;
using UnderstandingStructureApp.Interfaces;

namespace UnderstandingStructureApp.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;
        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        public IActionResult Index()
        {
            try
            {
                var pizzas = _pizzaService.GetAllPizzas();
                return View(pizzas);
            }
            catch (System.Exception e)
            {
                ViewBag.ErrorMessage = "There was an error in retrieving the pizzas ... "+e.Message;
                return View();
            }
            
        }
    }
}
