using PizzaStoreAPI.Exceptions;
using PizzaStoreAPI.Interfaces;
using PizzaStoreAPI.Models;

namespace PizzaStoreAPI.Repositories
{
    public class PizzaRepository :IRepository<int, Pizza>
    {
        static List<Pizza> pizzas = new List<Pizza>()
        {
            new Pizza(){Id=1, Name="Margherita", Price=100, Quantity=10, Image="https://cdn.apartmenttherapy.info/image/fetch/f_auto,q_auto:eco,w_1460/https://storage.googleapis.com/gen-atmedia/3/2012/07/f2203c0e403286947dcf80815b656236fec71e88.jpeg", Description="Classic Margherita Pizza"},
            new Pizza(){Id=2, Name="Pepperoni", Price=150, Quantity=10, Image="https://www.modernhoney.com/wp-content/uploads/2022/10/Homemade-Pepperoni-Pizza-with-Hot-Honey-1-scaled.jpg",Description="Pepperoni Pizza"}
        };
        public async Task<Pizza> Add(Pizza entity)
        {
            if (pizzas.Count == 0)
            {
                entity.Id = 1;
            }
            else
                entity.Id = pizzas.Max(c => c.Id) + 1;
            pizzas.Add(entity);
            return entity;
        }

        public async Task<Pizza> Delete(int key)
        {
            var pizza = await Get(key);
            pizzas.Remove(pizza);
            return pizza;
        }

        public async Task<Pizza> Get(int key)
        {
            var pizza = pizzas.FirstOrDefault(c => c.Id == key);
            if (pizza == null)
            {
                throw new NoEntityFoundException("Pizza", key);
            }
            return pizza;
        }

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            if (pizzas.Count == 0)
            {
                throw new CollectionEmptyException("Pizza");
            }
            return pizzas;
        }

        public async Task<Pizza> Update(Pizza entity)
        {
            var pizza = await Get(entity.Id);

            if (pizza == null)
            {
                throw new NoEntityFoundException("Pizza", entity.Id);
            }
            pizza.Name = entity.Name;
            pizza.Price = entity.Price;
            pizza.Image = entity.Image;
            pizza.Description = entity.Description;
            pizza.Quantity = entity.Quantity;
            return pizza;
        }
    }
}
