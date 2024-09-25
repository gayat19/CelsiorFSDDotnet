namespace PizzaStoreAPI.Models.DTOs
{
    public class CartDTO : IEquatable<CartDTO>
    {
        public int CartNumber { get; set; }
        public List<PizzaCartDTO> Pizzas { get; set; }
        public CartDTO()
        {
            Pizzas = new List<PizzaCartDTO>();
        }

        public bool Equals(CartDTO? other)
        {
            return (this ?? new CartDTO()).CartNumber == (other ?? new CartDTO()).CartNumber;
        }
    }
}
