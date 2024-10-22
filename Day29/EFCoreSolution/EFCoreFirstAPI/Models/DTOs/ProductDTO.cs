namespace EFCoreFirstAPI.Models.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float PricePerUnit { get; set; }
        public string BasicImage { get; set; } = string.Empty;
    }
}
