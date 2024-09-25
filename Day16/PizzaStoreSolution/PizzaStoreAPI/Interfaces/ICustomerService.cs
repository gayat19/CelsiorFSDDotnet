using PizzaStoreAPI.Models;

namespace PizzaStoreAPI.Interfaces
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Pizza>> ViewPizzas();

    }
}
