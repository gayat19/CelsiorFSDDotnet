using PizzaStoreAPI.Exceptions;
using PizzaStoreAPI.Interfaces;
using PizzaStoreAPI.Models;

namespace PizzaStoreAPI.Repositories
{
    public class OrderRepository : IRepository<int, Order>
    {
        static List<Order> orders = new List<Order>();
        public async Task<Order> Add(Order entity)
        {
            if (orders.Count == 0)
                entity.OrderNumber = 1;
            else
                entity.OrderNumber = orders.Max(o => o.OrderNumber) + 1;
            orders.Add(entity);
            return entity;
        }

        public async Task<Order> Delete(int key)
        {
            var order = await Get(key);
            orders.Remove(order);
            return order;
        }

        public async Task<Order> Get(int key)
        {
            var order = orders.FirstOrDefault(c => c.OrderNumber == key);
            if (order == null)
            {
                throw new NoEntityFoundException("Order", key);
            }
            return order;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            if (orders.Count == 0)
            {
                throw new CollectionEmptyException("Order");
            }
            return orders;
        }


        public async Task<Order> Update(Order entity)
        {
            var order = await Get(entity.OrderNumber);

            if (order == null)
            {
                throw new NoEntityFoundException("Order", entity.OrderNumber);
            }
            order.CustomerId = entity.CustomerId;
            order.TotalAmount = entity.TotalAmount;
            order.PaymentMethod = entity.PaymentMethod;
            order.IsPaymnetSuccess = entity.IsPaymnetSuccess;
            order.OrderStatus = entity.OrderStatus;
            return order;

        }
    }
}
