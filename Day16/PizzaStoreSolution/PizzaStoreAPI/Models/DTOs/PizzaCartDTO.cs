namespace PizzaStoreAPI.Models.DTOs
{
    public class PizzaCartDTO : IEquatable<PizzaCartDTO>
    {
        public int PizzaId { get; set; }
        public string PizzaName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }

        public bool Equals(PizzaCartDTO? other)
        {
            return (this ?? new PizzaCartDTO()).PizzaId == (other ?? new PizzaCartDTO()).PizzaId;
        }
    }
}
