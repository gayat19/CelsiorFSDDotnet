using PizzaStoreAPI.Interfaces;
using PizzaStoreAPI.Models;
using PizzaStoreAPI.Repositories;

namespace PizzaStoreAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<int, Pizza> _pizzaRepository;

        public CustomerService(IRepository<int,Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
        public async Task<IEnumerable<Pizza>> ViewPizzas()
        {
            var pizzas = (await _pizzaRepository.GetAll()).ToList().OrderBy(p => p.Name);
            return pizzas;
        }
    }
}
