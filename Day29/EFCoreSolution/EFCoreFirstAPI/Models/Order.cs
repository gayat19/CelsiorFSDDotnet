using System.ComponentModel.DataAnnotations;

namespace EFCoreFirstAPI.Models
{
    public class Order
    {
        [Key]
        public int OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalValue { get; set; }
        public string OrderStatus { get; set; } = string.Empty;

        public Customer Customer { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            Customer = new Customer();
            OrderDetails = new List<OrderDetail>();
        }
    }
}
