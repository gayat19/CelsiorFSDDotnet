namespace UnderstandingStructureApp.Models
{
    public class PizzaImages : IEquatable<PizzaImages>
    {
        public PizzaImages()
        {
            Images = new List<string>();
        }
        public int Id { get; set; }
        public List<string> Images { get; set; }

        public bool Equals(PizzaImages? other)
        {
            return this.Id == other.Id;
        }
    }
}
