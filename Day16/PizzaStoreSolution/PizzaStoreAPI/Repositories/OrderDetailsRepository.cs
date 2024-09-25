using PizzaStoreAPI.Exceptions;
using PizzaStoreAPI.Interfaces;
using PizzaStoreAPI.Models;

namespace PizzaStoreAPI.Repositories
{
    public class OrderDetailsRepository : IRepository<int, OrderDetails>
    {
        static List<OrderDetails> orderDetails = new List<OrderDetails>();
        public async Task<OrderDetails> Add(OrderDetails entity)
        {
            if(orderDetails.Count == 0)
                entity.SiNo = 1;
            else
                entity.OrderNumber = orderDetails.Max(o => o.SiNo) + 1;
            orderDetails.Add(entity);
            return entity;
        }

        public async Task<OrderDetails> Delete(int key)
        {
            var orderDetail = await Get(key);
            orderDetails.Remove(orderDetail);
            return orderDetail;
        }

        public async Task<OrderDetails> Get(int key)
        {
            var orderDetail = orderDetails.FirstOrDefault(c => c.SiNo == key);
            if (orderDetail == null)
            {
                throw new NoEntityFoundException("OrderDetails", key);
            }
            return orderDetail;
        }

        public async Task<IEnumerable<OrderDetails>> GetAll()
        {
            if (orderDetails.Count == 0)
            {
                throw new CollectionEmptyException("OrderDetails");
            }
            return orderDetails;
        }

        public async Task<OrderDetails> Update(OrderDetails entity)
        {
            var orderDetail = await Get(entity.SiNo);

            if (orderDetail == null)
            {
                throw new NoEntityFoundException("Order", entity.OrderNumber);
            }
            orderDetail.OrderNumber = entity.OrderNumber;
            orderDetail.PizzaId = entity.PizzaId;
            orderDetail.Quantity = entity.Quantity;
            orderDetail.Price = entity.Price;
            orderDetail.Discount = entity.Discount;
            return orderDetail;
        }
    }
}
