namespace ShoppingApplication.Models
{
    public class Product : IEquatable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string? Image { get; set; }

        public bool Equals(Product? other)
        {
            return this.Id == other.Id;
        }
    }
}
