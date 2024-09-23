namespace UnderstandingStructureApp.Models
{
    public class Pizza : IEquatable<Pizza>
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }

        public bool Equals(Pizza? other)
        {
            return this.Id == other.Id;
        }
    }
}
