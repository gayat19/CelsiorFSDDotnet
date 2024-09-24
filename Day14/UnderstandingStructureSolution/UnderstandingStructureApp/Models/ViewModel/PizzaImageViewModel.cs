namespace UnderstandingStructureApp.Models.ViewModel
{
    public class PizzaImageViewModel
    {
        public int Id { get; set; }
        public List<string> Images { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }

        public PizzaImageViewModel()
        {
            Images = new List<string>();
        }
    }
}
