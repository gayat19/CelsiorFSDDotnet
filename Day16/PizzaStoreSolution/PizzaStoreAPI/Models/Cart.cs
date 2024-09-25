namespace PizzaStoreAPI.Models
{
    public class Cart : IEquatable<Cart>
    {
        public int CartNumber { get; set; }
        public int CustomerId { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public Cart()
        {
            Pizzas = new List<Pizza>();
        }

        public bool Equals(Cart? other)
        {
            return (this ?? new Cart()).CartNumber == (other ?? new Cart()).CartNumber;
        }
    }
}
