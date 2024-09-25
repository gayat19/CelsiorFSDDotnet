using PizzaStoreAPI.Exceptions;
using PizzaStoreAPI.Interfaces;
using PizzaStoreAPI.Models;

namespace PizzaStoreAPI.Repositories
{
    public class CartRepository : IRepository<int, Cart>
    {
        static List<Cart> carts = new List<Cart>();
  

        public async Task<Cart> Add(Cart entity)
        {
            if(carts.Count == 0)
                entity.CartNumber = 1;
            else
                entity.CartNumber = carts.Max(c => c.CartNumber) + 1;
            carts.Add(entity);
            return entity;
        }

        public async Task<Cart> Delete(int key)
        {
            var cart = await Get(key);
            carts.Remove(cart);
            return cart;
        }

        public async Task<Cart> Get(int key)
        {
            var cart = carts.FirstOrDefault(c => c.CartNumber == key);
            if (cart == null)
            {
                throw new NoEntityFoundException("Cart", key);
            }
            return cart;
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            if (carts.Count == 0)
            {
                throw new CollectionEmptyException("Cart");
            }
            return carts;
        }


        public async Task<Cart> Update(Cart entity)
        {
            var cart = await Get(entity.CartNumber);

            if (cart == null)
            {
                throw new NoEntityFoundException("Cart", entity.CartNumber);
            }
            cart.CustomerId = entity.CustomerId;
            cart.Pizzas = entity.Pizzas;
            return cart;
        }
    }
}
