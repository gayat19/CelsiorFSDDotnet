namespace UnderstandingStructureApp.Models
{
    public class Pizza : IEquatable<Pizza>
    {
        public int Id{ get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Image { get; set; } = string.Empty;

        public bool Equals(Pizza? other)
        {
            return this.Id == (other??new Pizza()).Id;
        }
    }
}
