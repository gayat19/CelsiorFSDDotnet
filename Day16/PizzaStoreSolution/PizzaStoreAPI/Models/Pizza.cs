namespace PizzaStoreAPI.Models
{
    public class Pizza : IEquatable<Pizza>
    {
        public int Id { get; set; }
        public  string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; } = string.Empty;
        public string  Description { get; set; } = string.Empty;

        public bool Equals(Pizza? other)
        {
            return (this??new Pizza()).Id == (other ?? new Pizza()).Id;
        }
    }
}
