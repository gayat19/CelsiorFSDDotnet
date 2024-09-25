namespace PizzaStoreAPI.Models
{
    public enum OrderStatus
    {
        Created,
        Processing,
        Success,
        Delivered,
        Pending,
        Cancelled
    }
    public class Order : IEquatable<Order>
    {
        public int OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public float TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public bool IsPaymnetSuccess { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public bool Equals(Order? other)
        {
            return (this ?? new Order()).OrderNumber == (other ?? new Order()).OrderNumber;
        }
    }
}
