using UnderstandingStructureApp.Interfaces;
using UnderstandingStructureApp.Models;
using UnderstandingStructureApp.Repositories;

namespace UnderstandingStructureApp.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _pizzaRepository;
        private readonly IRepository<int, PizzaImages> _imagesRepository;

        public PizzaService(IRepository<int, Pizza> repository,IRepository<int,PizzaImages> imagesRepository)//comming as an injection from the provider
        {
            _pizzaRepository = repository;
            _imagesRepository = imagesRepository;
        }
        public List<Pizza> GetAllPizzas()
        {
            var pizzas = _pizzaRepository.GetAll();
            for (int i = 0; i < pizzas.Count; i++)
            {
                pizzas[i].Image = "/images/"+ pizzas[i].Image;
            }
            return pizzas;
        }
    }
}
